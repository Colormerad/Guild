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
    public class SpecialsRepositoryADO : ISpecialsRepository
    {
        public List<Specials> GetAll()
        {
            List<Specials> specials = new List<Specials>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Specials currentRow = new Specials();
                        currentRow.SpecialId = (int)dr["SpecialId"];
                        currentRow.SpecialName = dr["SpecialName"].ToString();
                        currentRow.SpecialDescription = dr["SpecialDescription"].ToString();
                        currentRow.SpecialImageFileName = dr["SpecialImageFileName"].ToString();

                        specials.Add(currentRow);
                    }

                }
            }

            return specials;
        }

        public Specials  GetById(int SpecialId)
        {
            Specials special = new Specials();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SpecialId", SpecialId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        special.SpecialId = SpecialId;
                        special.SpecialName = dr["SpecialName"].ToString();
                        special.SpecialDescription = dr["SpecialDescription"].ToString();
                        special.SpecialImageFileName = dr["SpecialImageFileName"].ToString();

                    }
                    else
                    {
                        special = null;
                    }
                }
            }
            return special;
        }

        public void Insert(Specials specials)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@SpecialId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@SpecialName", specials.SpecialName);
                cmd.Parameters.AddWithValue("@SpecialDescription", specials.SpecialDescription);
                cmd.Parameters.AddWithValue("@SpecialImageFileName", specials.SpecialImageFileName);
               
                cn.Open();

                cmd.ExecuteNonQuery();

                specials.SpecialId = (int)param.Value;
            }

        }


        public void Delete(int SpecialId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SpecialId", SpecialId);

                cn.Open();

                cmd.ExecuteNonQuery();

            }
        }
    }
}
