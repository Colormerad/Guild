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
    public class PurchaseTypeRepositoryADO : IPurchaseTypeRepository
    {
        
        public List<PurchaseType> GetAll()
        {
            List<PurchaseType> PurchaseTypes = new List<PurchaseType>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchaseTypeSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        PurchaseType currentRow = new PurchaseType();
                        currentRow.PurchaseTypeId = (int)dr["PurchaseTypeId"];
                        currentRow.PurchaseTypeName = dr["PurchaseTypeName"].ToString();

                        PurchaseTypes.Add(currentRow);
                    }

                }
            }

            return PurchaseTypes;
        }

        public PurchaseType GetById(int PurchaseTypeId)
        {
            PurchaseType pt = new PurchaseType();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchaseTypeSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PurchaseTypeId", PurchaseTypeId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        pt.PurchaseTypeId = PurchaseTypeId;
                        pt.PurchaseTypeName = dr["PurchaseTypeName"].ToString();
                    }
                    else
                    {
                        pt = null;
                    }
                }
            }
            return pt;
        }
    }
}
