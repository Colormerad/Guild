using GuildCars.Data.Interfaces;
using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.ADO
{
    public class InventoryReportRepositoryADO  : IInventoryReportRepository
    {
        public List<NewInventoryReportQuery> GetAllNew()
        {
            List<NewInventoryReportQuery> newReport = new List<NewInventoryReportQuery>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllNewVehicleReports", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        NewInventoryReportQuery currentRow = new NewInventoryReportQuery();
                        currentRow.Total = (int)dr["Total"];
                        currentRow.Count = (int)dr["Count"];
                        currentRow.Year = (int)dr["Year"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();

                        newReport.Add(currentRow);
                    }

                }
            }

            return newReport;
        }

        public List<UsedInventoryReportQuery> GetAllUsed()
        {
            List<UsedInventoryReportQuery> usedReport = new List<UsedInventoryReportQuery>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllUsedVehicleReports", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        UsedInventoryReportQuery currentRow = new UsedInventoryReportQuery();
                        currentRow.Total = (int)dr["Total"];
                        currentRow.Count = (int)dr["Count"];
                        currentRow.Year = (int)dr["Year"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();

                        usedReport.Add(currentRow);
                    }

                }
            }

            return usedReport;
        }
    }
}
