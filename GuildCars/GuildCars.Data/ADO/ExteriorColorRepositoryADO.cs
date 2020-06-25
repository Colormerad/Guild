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
    public class ExteriorColorRepositoryADO : IExteriorColorRepository
    {
        
        public List<ExteriorColor> GetAll()
        {
            List<ExteriorColor> ExteriorColors = new List<ExteriorColor>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ExteriorColorSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ExteriorColor currentRow = new ExteriorColor();
                        currentRow.ExteriorColorId = (int)dr["ExteriorColorId"];
                        currentRow.ExteriorColorName = dr["ExteriorColorName"].ToString();

                        ExteriorColors.Add(currentRow);
                    }

                }
            }

            return ExteriorColors;
        }

        public ExteriorColor GetById(int ExteriorColorId)
        {
            ExteriorColor ec = new ExteriorColor();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ExteriorColorSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ExteriorColorId", ExteriorColorId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                       ec.ExteriorColorId = ExteriorColorId;
                       ec.ExteriorColorName = dr["ExteriorColorName"].ToString();
                    }
                    else
                    {
                        ec = null;
                    }
                }
            }
            return ec;
        }
    }
}
