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
    public class VehicleRepositoryADO : IVehicleRepository
    {

    
        public List<Vehicles> GetAll()
        {
            List<Vehicles> vehicles = new List<Vehicles>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicles currentRow = new Vehicles();
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.Year = (int)dr["Year"];
                        currentRow.Description = dr["Description"].ToString();
                        currentRow.ImageFileName = dr["ImageFileName"].ToString();
                        currentRow.MSRP = (int)dr["MSRP"];
                        currentRow.Mileage = (int)dr["Mileage"];
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.SalePrice = (int)dr["SalePrice"];
                        currentRow.MakeId = (int)dr["MakeId"];
                        currentRow.ModelId = (int)dr["ModelId"];
                        currentRow.NewUsedId = (int)dr["NewUsedId"];
                        currentRow.BodyStyleId = (int)dr["BodyStyleId"];
                        currentRow.InteriorColorId = (int)dr["InteriorColorId"];
                        currentRow.ExteriorColorId = (int)dr["ExteriorColorId"];
                        currentRow.TransmissionId = (int)dr["TransmissionId"];
                        currentRow.DateAdded = (DateTime)dr["DateAdded"];
                        currentRow.HasBeenSold = (bool)dr["HasBeenSold"];
                        currentRow.IsFeatured = (bool)dr["IsFeatured"];



                        vehicles.Add(currentRow);
                    }
                }
            }

            return vehicles;
        }

        public Vehicles GetById(int VehicleId)
        {
            Vehicles vehicle = new Vehicles();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleId", VehicleId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        vehicle.VehicleId = VehicleId;
                        vehicle.Year = (int)dr["Year"];
                        vehicle.Description = dr["Description"].ToString();
                        vehicle.ImageFileName = dr["ImageFileName"].ToString();
                        vehicle.MSRP = (int)dr["MSRP"];
                        vehicle.Mileage = (int)dr["Mileage"];
                        vehicle.VIN = dr["VIN"].ToString();
                        vehicle.SalePrice = (int)dr["SalePrice"];
                        vehicle.MakeId = (int)dr["MakeId"];
                        vehicle.ModelId = (int)dr["ModelId"];
                        vehicle.NewUsedId = (int)dr["NewUsedId"];
                        vehicle.BodyStyleId = (int)dr["BodyStyleId"];
                        vehicle.InteriorColorId = (int)dr["InteriorColorId"];
                        vehicle.ExteriorColorId = (int)dr["ExteriorColorId"];
                        vehicle.TransmissionId = (int)dr["TransmissionId"];
                        vehicle.DateAdded = (DateTime)dr["DateAdded"];
                        vehicle.HasBeenSold = (bool)dr["HasBeenSold"];
                        vehicle.IsFeatured = (bool)dr["IsFeatured"];
                    }
                    else
                    {
                        vehicle = null;
                    }
                }
            }
            return vehicle;
        }

        public void Insert(Vehicles vehicles)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@VehicleId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@Year", vehicles.Year);
                cmd.Parameters.AddWithValue("@Description", vehicles.Description);
                cmd.Parameters.AddWithValue("@ImageFileName", vehicles.ImageFileName);


                
                cmd.Parameters.AddWithValue("@MSRP", vehicles.MSRP);
                cmd.Parameters.AddWithValue("@Mileage", vehicles.Mileage);
                cmd.Parameters.AddWithValue("@VIN", vehicles.VIN);
                cmd.Parameters.AddWithValue("@SalePrice", vehicles.SalePrice);
                cmd.Parameters.AddWithValue("@MakeId", vehicles.MakeId);
                cmd.Parameters.AddWithValue("@ModelId", vehicles.ModelId);
                cmd.Parameters.AddWithValue("@NewUsedId", vehicles.NewUsedId);
                cmd.Parameters.AddWithValue("@BodyStyleId", vehicles.BodyStyleId);
                cmd.Parameters.AddWithValue("@InteriorColorId", vehicles.InteriorColorId);
                cmd.Parameters.AddWithValue("@ExteriorColorId", vehicles.ExteriorColorId);
                cmd.Parameters.AddWithValue("@TransmissionId", vehicles.TransmissionId);
                cmd.Parameters.AddWithValue("@DateAdded", vehicles.DateAdded);
                cmd.Parameters.AddWithValue("@HasBeenSold", vehicles.HasBeenSold);
                cmd.Parameters.AddWithValue("@IsFeatured", vehicles.IsFeatured);

                cn.Open();

                cmd.ExecuteNonQuery();

                vehicles.VehicleId = (int)param.Value;
            }

        }

        public void Update(Vehicles vehicles)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleId", vehicles.VehicleId);
                cmd.Parameters.AddWithValue("@Year", vehicles.Year);
                cmd.Parameters.AddWithValue("@Description", vehicles.Description);
                
                cmd.Parameters.AddWithValue("@MSRP", vehicles.MSRP);
                cmd.Parameters.AddWithValue("@Mileage", vehicles.Mileage);
                cmd.Parameters.AddWithValue("@VIN", vehicles.VIN);
                cmd.Parameters.AddWithValue("@SalePrice", vehicles.SalePrice);
                cmd.Parameters.AddWithValue("@MakeId", vehicles.MakeId);
                cmd.Parameters.AddWithValue("@ModelId", vehicles.ModelId);
                cmd.Parameters.AddWithValue("@NewUsedId", vehicles.NewUsedId);
                cmd.Parameters.AddWithValue("@BodyStyleId", vehicles.BodyStyleId);
                cmd.Parameters.AddWithValue("@InteriorColorId", vehicles.InteriorColorId);
                cmd.Parameters.AddWithValue("@ExteriorColorId", vehicles.ExteriorColorId);
                cmd.Parameters.AddWithValue("@TransmissionId", vehicles.TransmissionId);
                cmd.Parameters.AddWithValue("@DateAdded", vehicles.DateAdded);
                cmd.Parameters.AddWithValue("@HasBeenSold", vehicles.HasBeenSold);
                cmd.Parameters.AddWithValue("@IsFeatured", vehicles.IsFeatured);

                if (vehicles.ImageFileName == string.Empty)
                {
                    
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ImageFileName", vehicles.ImageFileName);
                }

                cn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public void Delete(int VehicleId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleId", VehicleId);

                cn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public IEnumerable<VehicleCondition> GetAllNew()
        {
            List<VehicleCondition> vehicles = new List<VehicleCondition>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleSelectCondition", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NewUsedName", "New");

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleCondition currentRow = new VehicleCondition();
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.Year = (int)dr["Year"];
                        currentRow.ImageFileName = dr["ImageFileName"].ToString();
                        currentRow.SalePrice = (int)dr["SalePrice"];
                        currentRow.MakeId = (int)dr["MakeId"];
                        currentRow.ModelId = (int)dr["ModelId"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();

                        currentRow.NewUsed = "New";


                        vehicles.Add(currentRow);
                    }
                }
            }

            return vehicles;
        }

        public IEnumerable<VehicleCondition> GetAllUsed()
        {
            List<VehicleCondition> vehicles = new List<VehicleCondition>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleSelectCondition", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NewUsedName", "Used");

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleCondition currentRow = new VehicleCondition();
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.Year = (int)dr["Year"];
                        currentRow.ImageFileName = dr["ImageFileName"].ToString();
                        currentRow.SalePrice = (int)dr["SalePrice"];
                        currentRow.MakeId = (int)dr["MakeId"];
                        currentRow.ModelId = (int)dr["ModelId"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();

                        currentRow.NewUsed = "Used";


                        vehicles.Add(currentRow);
                    }
                }
            }

            return vehicles;
        }

        public IEnumerable<FeaturedVehicle> GetAllFeatured()
        {
            List<FeaturedVehicle> vehicles = new List<FeaturedVehicle>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleSelectFeatured", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IsFeatured", true);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        FeaturedVehicle currentRow = new FeaturedVehicle();
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.Year = (int)dr["Year"];
                        currentRow.ImageFileName = dr["ImageFileName"].ToString();
                        currentRow.SalePrice = (int)dr["SalePrice"];
                        currentRow.MakeId = (int)dr["MakeId"];
                        currentRow.ModelId = (int)dr["ModelId"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();

                        currentRow.IsFeatured = true;


                        vehicles.Add(currentRow);
                    }
                }
            }

            return vehicles;
        }

        public VehicleDetails GetVehicleDetails(int VehicleId)
        {
            VehicleDetails vehicle = new VehicleDetails();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleDetails", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleId", VehicleId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {


                        vehicle.VehicleId = VehicleId;
                        vehicle.Year = (int)dr["Year"];
                        vehicle.Description = dr["Description"].ToString();
                        vehicle.ImageFileName = dr["ImageFileName"].ToString();
                        vehicle.MSRP = (int)dr["MSRP"];
                        vehicle.Mileage = (int)dr["Mileage"];
                        vehicle.VIN = dr["VIN"].ToString();
                        vehicle.SalePrice = (int)dr["SalePrice"];
                        vehicle.MakeId = (int)dr["MakeId"];
                        vehicle.ModelId = (int)dr["ModelId"];
                        vehicle.NewUsedId = (int)dr["NewUsedId"];
                        vehicle.BodyStyleId = (int)dr["BodyStyleId"];
                        vehicle.InteriorColorId = (int)dr["InteriorColorId"];
                        vehicle.ExteriorColorId = (int)dr["ExteriorColorId"];
                        vehicle.TransmissionId = (int)dr["TransmissionId"];
                        vehicle.MakeName = dr["MakeName"].ToString();
                        vehicle.ModelName = dr["ModelName"].ToString();
                        vehicle.InteriorColorName = dr["InteriorColorName"].ToString();
                        vehicle.ExteriorColorName = dr["ExteriorColorName"].ToString();
                        vehicle.TransmissionName = dr["TransmissionName"].ToString();
                        vehicle.NewUsedName = dr["NewUsedName"].ToString();
                        vehicle.BodyStyleName = dr["BodyStyleName"].ToString();


                    }
                }
            }

            return vehicle;
        }

        public List<VehicleDetails> searchVehicles(SearchCarsQuery search)
        {
            List<VehicleDetails> vehicles = new List<VehicleDetails>();
            var sql = " SELECT Vehicles.VehicleId,Vehicles.[Year],Make.MakeName,Model.ModelName,BodyStyle.BodyStyleName, " +
                "Vehicles.Description, Vehicles.ImageFileName, Vehicles.Mileage, Vehicles.MakeId, Vehicles.ModelId, " +
                "Vehicles.BodyStyleId, Vehicles.InteriorColorId, Vehicles.ExteriorColorId, Vehicles.TransmissionId, Vehicles.NewUsedId, " +
                "Transmission.TransmissionName, ExteriorColor.ExteriorColorName, InteriorColor.InteriorColorName, " +
                "NewUsed.NewUsedName, Vehicles.VIN, Vehicles.SalePrice, Vehicles.MSRP " +
                "FROM Vehicles " +
                "JOIN Make ON Vehicles.MakeId = Make.MakeId " +
                "JOIN Model ON Vehicles.ModelId = Model.ModelId " +
                "JOIN Transmission ON Vehicles.TransmissionId = Transmission.TransmissionId " +
                "JOIN ExteriorColor ON Vehicles.ExteriorColorId = ExteriorColor.ExteriorColorId " +
                "JOIN InteriorColor ON Vehicles.InteriorColorId = InteriorColor.InteriorColorId " +
                "JOIN BodyStyle ON Vehicles.BodyStyleId = BodyStyle.BodyStyleId " +
                "JOIN NewUsed ON Vehicles.NewUsedId = NewUsed.NewUsedId " +
                "WHERE 1 = 1 ";
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;

                VehicleDetails vehicle = new VehicleDetails();
                var year = 0;
                if (int.TryParse(search.SearchField, out year))
                {
                    sql += " AND Vehicles.[Year] =  @Year ";
                    cmd.Parameters.AddWithValue("@Year", year);
                }
                else if (search.SearchField != null)
                {
                    sql += " AND (Make.MakeName LIKE @searchField OR Model.ModelName LIKE @searchField) ";
                    cmd.Parameters.AddWithValue("@searchField", "%" + search.SearchField + "%");
                }

                if (search.YearMax != -1)
                {
                    sql += " AND Vehicles.[Year] < @yearMax ";
                    cmd.Parameters.AddWithValue("@yearMax", search.YearMax);
                }

                if (search.YearMin != -1)
                {
                    sql += " AND Vehicles.[Year] > @yearMin ";
                    cmd.Parameters.AddWithValue("@yearMin", search.YearMin);
                }

                if (search.PriceMax != -1)
                {
                    sql += " AND Vehicles.SalePrice < @priceMax ";
                    cmd.Parameters.AddWithValue("@priceMax", search.PriceMax);
                }

                if (search.PriceMin != -1)
                {
                    sql += " AND Vehicles.SalePrice > @priceMin ";
                    cmd.Parameters.AddWithValue("@PriceMin", search.PriceMin);
                }
                if (search.Condition.ToUpper() != "ALL")
                {
                    cmd.Parameters.AddWithValue("@Condition", search.Condition);
                    sql += " AND NewUsed.NewUsedName = @Condition ";
                }

                sql += "AND HasBeenSold = 0";

                cmd.CommandText = sql;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        VehicleDetails currentRow = new VehicleDetails();
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.Year = (int)dr["Year"];
                        currentRow.Description = dr["Description"].ToString();
                        currentRow.ImageFileName = dr["ImageFileName"].ToString();
                        currentRow.MSRP = (int)dr["MSRP"];
                        currentRow.Mileage = (int)dr["Mileage"];
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.SalePrice = (int)dr["SalePrice"];
                        currentRow.MakeId = (int)dr["MakeId"];
                        currentRow.ModelId = (int)dr["ModelId"];
                        currentRow.NewUsedId = (int)dr["NewUsedId"];
                        currentRow.BodyStyleId = (int)dr["BodyStyleId"];
                        currentRow.InteriorColorId = (int)dr["InteriorColorId"];
                        currentRow.ExteriorColorId = (int)dr["ExteriorColorId"];
                        currentRow.TransmissionId = (int)dr["TransmissionId"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.InteriorColorName = dr["InteriorColorName"].ToString();
                        currentRow.ExteriorColorName = dr["ExteriorColorName"].ToString();
                        currentRow.TransmissionName = dr["TransmissionName"].ToString();
                        currentRow.NewUsedName = dr["NewUsedName"].ToString();
                        currentRow.BodyStyleName = dr["BodyStyleName"].ToString();

                        vehicles.Add(currentRow);
                    }
                }
            }

            return vehicles;
        }

        public List<Model> modelForm(Make make)
        {
            List<Model> models = new List<Model>();
            var sql = " SELECT ModelName FROM Model INNER JOIN Make ON Make.MakeId = Model.MakeId WHERE ";
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                var year = 0;
                if (make.MakeId != null)
                {
                    sql += " Model.MakeId =  @make.MakeId ";
                    cmd.Parameters.AddWithValue("@make.MakeId", make.MakeId);
                }
                cmd.CommandText = sql;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        Model currentRow = new Model();
                        currentRow.MakeId = make.MakeId;
                        currentRow.ModelId = (int)dr["ModelId"];
                        currentRow.ModelName = dr["ModelName"].ToString();

                        models.Add(currentRow);
                    }
                }
            }
            return models;
        }
    }
}
