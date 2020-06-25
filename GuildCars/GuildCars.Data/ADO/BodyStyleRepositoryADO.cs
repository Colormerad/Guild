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
    public class BodyStyleRepositoryADO : IBodyStyleRepository
    {
       
        public List<BodyStyle> GetAll()
        {
            List<BodyStyle> BodyStyles = new List<BodyStyle>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("BodyStyleSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BodyStyle currentRow = new BodyStyle();
                        currentRow.BodyStyleId = (int)dr["BodyStyleId"];
                        currentRow.BodyStyleName = dr["BodyStyleName"].ToString();

                        BodyStyles.Add(currentRow);
                    }

                }
            }

            return BodyStyles;
        }

        public BodyStyle GetById(int BodyStyleId)
        {
            BodyStyle body = new BodyStyle();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("BodyStyleSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BodyStyleId", BodyStyleId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        body.BodyStyleId = BodyStyleId;
                        body.BodyStyleName = dr["BodyStyleName"].ToString();
                    }
                    else
                    {
                        body = null;
                    }
                }
            }
            return body;
        }
    }
}
