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
    public class ModelRepositoryADO : IModelRepository
    {
        public List<Model> GetAll()
        {
            List<Model> models = new List<Model>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllModels", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Model currentRow = new Model();
                        currentRow.ModelId = (int)dr["ModelId"];
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.MakeId =(int) dr["MakeId"];
                        currentRow.UserId = dr["UserId"].ToString();
                        currentRow.AddedDate = (DateTime)dr["AddedDate"];

                        models.Add(currentRow);
                    }

                }
            }

            return models;
        }

        public Model GetByModelId(int ModelId)
        {
            Model model = new Model();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ModelId", ModelId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        model.ModelId = ModelId;
                        model.ModelName = dr["ModelName"].ToString();
                        model.MakeId = (int)dr["MakeId"];
                        model.UserId = dr["UserId"].ToString();
                        model.AddedDate = (DateTime)dr["AddedDate"];
                    }
                    else
                    {
                        model = null;
                    }
                }
            }
            return model;
        }

        public List<Model> GetAllByMakeId(int MakeId)
        {
            
            List<Model> models = new List<Model>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllModelsByMakeID", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MakeId", MakeId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        Model currentRow = new Model();
                        currentRow.MakeId = (int)dr["Makeid"];
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.ModelId = (int)dr["ModelId"];
                        currentRow.UserId = dr["UserId"].ToString();
                        currentRow.AddedDate = (DateTime)dr["AddedDate"];
                        models.Add(currentRow);                     
                    }
                }
            }
            return models;
        }


        public void Insert(Model model)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@ModelId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@ModelName", model.ModelName);
                cmd.Parameters.AddWithValue("@MakeId", model.MakeId);
                cmd.Parameters.AddWithValue("@UserId", model.UserId);
                cmd.Parameters.AddWithValue("@AddedDate", model.AddedDate);

                cn.Open();

                cmd.ExecuteNonQuery();

                model.ModelId = (int)param.Value;
            }

        }
    }
}

