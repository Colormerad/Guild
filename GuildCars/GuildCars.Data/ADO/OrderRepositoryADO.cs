using GuildCars.Data.Interfaces;
using GuildCars.Models.Queries;
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
    public class OrderRepositoryADO : IOrderRepository
    {
        public List<Orders> GetAll()
        {
            List<Orders> orders = new List<Orders>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("OrdersSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Orders currentRow = new Orders();
                        currentRow.OrderId = (int)dr["OrderId"];
                        currentRow.UserId = dr["UserId"].ToString();
                        currentRow.OrderDate = (DateTime)dr["OrderDate"];
                        currentRow.OrderTotal = (int)dr["OrderTotal"];
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.CustomerName = dr["CustomerName"].ToString();
                        currentRow.CustomerPhone = dr["CustomerPhone"].ToString();
                        currentRow.CustomerEmail = dr["CustomerEmail"].ToString();
                        currentRow.CustomerStreet1 = dr["CustomerStreet1"].ToString();
                        currentRow.CustomerCity = dr["CustomerCity"].ToString();
                        currentRow.CustomerState = dr["CustomerState"].ToString();
                        currentRow.CustomerZipcode = (int)dr["CustomerZipcode"];
                        currentRow.PurchaseTypeId = (int)dr["PurchaseTypeId"];

                        if (dr["CustomerStreet2"] != DBNull.Value)
                        {
                            currentRow.CustomerStreet2 = dr["CustomerStreet2"].ToString();
                        }

                        orders.Add(currentRow);
                    }

                }
            }

            return orders;
        }

        public Orders GetById(int OrderId)
        {
            Orders order = new Orders();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("OrderSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@OrderId", OrderId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        order.OrderId = OrderId;
                        order.UserId = dr["UserId"].ToString();
                        order.OrderDate = (DateTime)dr["OrderDate"];
                        order.OrderTotal = (int)dr["OrderTotal"];
                        order.VehicleId = (int)dr["VehicleId"];
                        order.CustomerName = dr["CustomerName"].ToString();
                        order.CustomerPhone = dr["CustomerPhone"].ToString();
                        order.CustomerEmail = dr["CustomerEmail"].ToString();
                        order.CustomerStreet1 = dr["CustomerStreet1"].ToString();
                        if (order.CustomerStreet2 == string.Empty)
                        {
                            cmd.Parameters.AddWithValue("@CustomerStreet2", string.Empty);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@CustomerStreet2", order.CustomerStreet2);
                        }
                        order.CustomerCity = dr["CustomerCity"].ToString();
                        order.CustomerState = dr["CustomerState"].ToString();
                        order.CustomerZipcode = (int)dr["CustomerZipcode"];
                        order.PurchaseTypeId = (int)dr["PurchaseTypeId"];
                    }
                    else
                    {
                        order = null;
                    }
                }
            }
            return order;
        }

        public void Insert(Orders orders)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("OrderInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@UserId", orders.UserId);
                cmd.Parameters.AddWithValue("@OrderDate", orders.OrderDate);
                cmd.Parameters.AddWithValue("@OrderTotal", orders.OrderTotal);
                cmd.Parameters.AddWithValue("@VehicleId", orders.VehicleId);
                cmd.Parameters.AddWithValue("@CustomerName", orders.CustomerName);
                cmd.Parameters.AddWithValue("@CustomerPhone", orders.CustomerPhone);
                cmd.Parameters.AddWithValue("@CustomerEmail", orders.CustomerEmail);
                cmd.Parameters.AddWithValue("@CustomerStreet1", orders.CustomerStreet1);
                
                cmd.Parameters.AddWithValue("@CustomerCity", orders.CustomerCity);
                cmd.Parameters.AddWithValue("@CustomerState", orders.CustomerState);
                cmd.Parameters.AddWithValue("@CustomerZipcode", orders.CustomerZipcode);
                cmd.Parameters.AddWithValue("@PurchaseTypeId", orders.PurchaseTypeId);
                
                if (orders.CustomerStreet2 == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@CustomerStreet2", string.Empty);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@CustomerStreet2", orders.CustomerStreet2);
                }
                

                cn.Open();

                cmd.ExecuteNonQuery();

                orders.OrderId = (int)param.Value;
            }

        }

        public void Update(Orders orders)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("OrderUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@OrderId", orders.OrderId);
                cmd.Parameters.AddWithValue("@UserId", orders.UserId);
                cmd.Parameters.AddWithValue("@OrderDate", orders.OrderDate);
                cmd.Parameters.AddWithValue("@OrderTotal", orders.OrderTotal);
                cmd.Parameters.AddWithValue("@VehicleId", orders.VehicleId);
                cmd.Parameters.AddWithValue("@CustomerName", orders.CustomerName);
                cmd.Parameters.AddWithValue("@CustomerPhone", orders.CustomerPhone);
                cmd.Parameters.AddWithValue("@CustomerEmail", orders.CustomerEmail);
                cmd.Parameters.AddWithValue("@CustomerStreet1", orders.CustomerStreet1);
                cmd.Parameters.AddWithValue("@CustomerCity", orders.CustomerCity);
                cmd.Parameters.AddWithValue("@CustomerState", orders.CustomerState);
                cmd.Parameters.AddWithValue("@CustomerZipcode", orders.CustomerZipcode);
                cmd.Parameters.AddWithValue("@PurchaseTypeId", orders.PurchaseTypeId);
                if (orders.CustomerStreet2 == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@CustomerStreet2", string.Empty);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@CustomerStreet2", orders.CustomerStreet2);
                }

                cn.Open();

                cmd.ExecuteNonQuery();

            }

        }

        public void Delete(int OrderId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("OrderDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@OrderId", OrderId);

                cn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public List<SalesResults> searchOrders(SearchOrdersQuery search)
        {
            List<SalesResults> results = new List<SalesResults>();
            var sql = "SELECT UserName, SUM(OrderTotal) AS TotalSales, Count(*) AS TotalVehicles " +
                      " FROM Orders " +
                      " JOIN AspNetUsers ON Orders.UserId = AspNetUsers.Id " +
                      "WHERE 1 = 1 ";
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                SalesResults result = new SalesResults();

                if (search.UserName != null)
                {
                    sql += " AND AspNetUsers.Id = @Id ";
                    cmd.Parameters.AddWithValue("@Id", search.UserName);
                }

                if (Convert.ToDateTime(search.MinOrderDate) != DateTime.MinValue)
                {
                    sql += " AND  OrderDate >= @minOrderDate ";
                    cmd.Parameters.AddWithValue("@minOrderDate", search.MinOrderDate);
                }

                if (Convert.ToDateTime(search.MaxOrderDate) != DateTime.MinValue )
                {
                    sql += " AND  OrderDate >= @maxOrderDate ";
                    cmd.Parameters.AddWithValue("@maxOrderDate", search.MaxOrderDate);
                }

                sql += " GROUP BY UserName ";

                cmd.CommandText = sql;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        SalesResults currentRow = new SalesResults();
                        currentRow.UserName = dr["UserName"].ToString();
                        currentRow.TotalSales = (int)dr["TotalSales"];
                        currentRow.TotalVehicles = (int)dr["TotalVehicles"];

                        results.Add(currentRow);
                    }
                }
            }

            return results;
        }   


    }
}
