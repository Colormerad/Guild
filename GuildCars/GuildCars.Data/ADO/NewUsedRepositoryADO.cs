using GuildCars.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using GuildCars.Models.Tables;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewUsed = GuildCars.Models.Tables.NewUsed;

namespace GuildCars.Data.ADO
{
    public class NewUsedRepositoryADO : INewUsedRepository
    {

       
        public List<NewUsed> GetAll()
        {
            List<NewUsed> NewUseds = new List<NewUsed>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("NewUsedSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        NewUsed currentRow = new NewUsed();
                        currentRow.NewUsedId = (int)dr["NewUsedId"];
                        currentRow.NewUsedName = dr["NewUsedName"].ToString();

                        NewUseds.Add(currentRow);
                    }

                }
            }

            return NewUseds;
        }

        public NewUsed GetById(int NewUsedId)
        {
            NewUsed condition = new NewUsed();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("NewUsedSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NewUsedId", NewUsedId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                       condition.NewUsedId = NewUsedId;
                        condition.NewUsedName = dr["NewUsedName"].ToString();
                    }
                    else
                    {
                        condition = null;
                    }
                }
            }
            return condition;
        }


    }
}
