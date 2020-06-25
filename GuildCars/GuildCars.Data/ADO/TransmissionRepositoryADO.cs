using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.ADO
{
    public class TransmissionRepositoryADO : ITransmissionRepository
    {

        
        public List<Transmission> GetAll()
        {
            List<Transmission> Transmissions = new List<Transmission>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TransmissionSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Transmission currentRow = new Transmission();
                        currentRow.TransmissionId = (int)dr["TransmissionId"];
                        currentRow.TransmissionName = dr["TransmissionName"].ToString();

                        Transmissions.Add(currentRow);
                    }

                }
            }

            return Transmissions;
        }

        public Transmission GetById(int TransmissionId)
        {
            Transmission transmission = new Transmission();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TransmissionSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TransmissionId", TransmissionId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        transmission.TransmissionId = TransmissionId;
                        transmission.TransmissionName = dr["TransmissionName"].ToString();
                    }
                    else
                    {
                        transmission = null;
                    }
                }
            }
            return transmission;
        }
    }
}
