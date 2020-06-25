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
    public class InteriorColorRepositoryADO : IInteriorColorRepository
    {

        
        public List<InteriorColor> GetAll()
        {
            List<InteriorColor> InteriorColors = new List<InteriorColor>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InteriorColorSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        InteriorColor currentRow = new InteriorColor();
                        currentRow.InteriorColorId = (int)dr["InteriorColorId"];
                        currentRow.InteriorColorName = dr["InteriorColorName"].ToString();

                        InteriorColors.Add(currentRow);
                    }

                }
            }

            return InteriorColors;
        }

        public InteriorColor GetById(int InteriorColorId)
        {
            InteriorColor ic = new InteriorColor();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InteriorColorSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@InteriorColorId", InteriorColorId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        ic.InteriorColorId = InteriorColorId;
                       ic.InteriorColorName = dr["InteriorColorName"].ToString();
                    }
                    else
                    {
                        ic = null;
                    }
                }
            }
            return ic;
        }
    }
}
