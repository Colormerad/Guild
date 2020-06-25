using GuildCars.Data.ADO;
using GuildCars.Models.Tables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Test.IntegrationTest
{
    [TestFixture]
    public class AdoTests
    {
        [SetUp]
        public void ResetData()
        {
            using(var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DbReset";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        [Test]
        public void CanLoadMakes()
        {
            var repo = new MakeRepositoryADO();

            var makes = repo.GetAll();
            Assert.AreEqual(3, makes.Count);
            Assert.AreEqual(1, makes[0].MakeId);
            Assert.AreEqual("Baddieux", makes[0].MakeName);
        }

        [Test]
        public void CanLoadModels()
        {
            var repo = new ModelRepositoryADO();

            var models = repo.GetAll();
            Assert.AreEqual(9, models.Count);
            Assert.AreEqual("Tooths", models[0].ModelName);
        }

        [Test]
        public void CanLoadTransmissions()
        {
            var repo = new TransmissionRepositoryADO();

            var transmissions = repo.GetAll();
            Assert.AreEqual(3, transmissions.Count);
            Assert.AreEqual("Automatic", transmissions[0].TransmissionName);

        }

        [Test]
        public void CanLoadNewUseds()
        {
            var repo = new NewUsedRepositoryADO();

            var NewUseds = repo.GetAll();
            Assert.AreEqual(2, NewUseds.Count);
            Assert.AreEqual("New", NewUseds[0].NewUsedName);

        }

        [Test]
        public void CanLoadBodyStyles()
        {
            var repo = new BodyStyleRepositoryADO();

            var BodyStyles = repo.GetAll();
            Assert.AreEqual(3, BodyStyles.Count);
            Assert.AreEqual("ATV", BodyStyles[0].BodyStyleName);

        }

        [Test]
        public void CanLoadExteriorColors()
        {
            var repo = new ExteriorColorRepositoryADO();

            var ExteriorColors = repo.GetAll();
            Assert.AreEqual(6, ExteriorColors.Count);
            Assert.AreEqual("Black", ExteriorColors[0].ExteriorColorName);

        }

        [Test]
        public void CanLoadInteriorColors()
        {
            var repo = new InteriorColorRepositoryADO();

            var InteriorColors = repo.GetAll();
            Assert.AreEqual(3, InteriorColors.Count);
            Assert.AreEqual("Black", InteriorColors[0].InteriorColorName);

        }

        [Test]
        public void CanLoadPurchaseTypes()
        {
            var repo = new PurchaseTypeRepositoryADO();

            var PurchaseTypes = repo.GetAll();
            Assert.AreEqual(2, PurchaseTypes.Count);
            Assert.AreEqual("Financing", PurchaseTypes[0].PurchaseTypeName);

        }

        [Test]
        public void CanLoadSpecials()
        {
            var repo = new SpecialsRepositoryADO();

            var specials = repo.GetAll();
            Assert.AreEqual(3, specials.Count);
            Assert.AreEqual("Flower Cup Champion", specials[0].SpecialName);

        }

        [Test]
        public void CanLoadOrders()
        {
            var repo = new OrderRepositoryADO();

            var orders = repo.GetAll();
            Assert.AreEqual(2, orders.Count);
        }

        [Test]
        public void CanLoadVehicles()
        {
            var repo = new VehicleRepositoryADO();

            var vehicles = repo.GetAll();
            Assert.AreEqual(9, vehicles.Count);
        }

        [Test]
        public void CanLoadVehicle()
        {
            var repo = new VehicleRepositoryADO();

            var vehicle = repo.GetById(1);
            Assert.IsNotNull(vehicle);
            Assert.AreEqual(1, vehicle.VehicleId);
            Assert.AreEqual(2019, vehicle.Year);
            Assert.AreEqual(false, vehicle.HasBeenSold);
        }
        [Test]
        public void NullVehicle()
        {
            var repo = new VehicleRepositoryADO();

            var vehicle = repo.GetById(40);
            Assert.IsNull(vehicle);
            
        }

        [Test]
        public void CanAddVehicle()
        {
            Vehicles vehicleToAdd = new Vehicles(); 
            var repo = new VehicleRepositoryADO();

            vehicleToAdd.Year = 2018;
            vehicleToAdd.Description = "TOADally awesome";
            vehicleToAdd.ImageFileName = "toad.png";
            vehicleToAdd.MSRP = 3400;
            vehicleToAdd.Mileage = 21000;
            vehicleToAdd.VIN = "8635H";
            vehicleToAdd.SalePrice = 18000;
            vehicleToAdd.MakeId = 3;
            vehicleToAdd.ModelId = 3;
            vehicleToAdd.NewUsedId = 2;
            vehicleToAdd.BodyStyleId = 3;
            vehicleToAdd.InteriorColorId = 3;
            vehicleToAdd.ExteriorColorId = 2;
            vehicleToAdd.TransmissionId = 2;
            vehicleToAdd.DateAdded = DateTime.Today;
            vehicleToAdd.HasBeenSold = false;
            vehicleToAdd.IsFeatured = false;

            repo.Insert(vehicleToAdd);

            Assert.AreEqual(10, vehicleToAdd.VehicleId);

        }

        [Test]
        public void CanUpdateVehicle()
        {
            Vehicles vehicleToAdd = new Vehicles();
            var repo = new VehicleRepositoryADO();

            vehicleToAdd.Year = 2018;
            vehicleToAdd.Description = "TOADally awesome";
            vehicleToAdd.ImageFileName = "toad.png";
            vehicleToAdd.MSRP = 3400;
            vehicleToAdd.Mileage = 21000;
            vehicleToAdd.VIN = "8635H";
            vehicleToAdd.SalePrice = 18000;
            vehicleToAdd.MakeId = 3;
            vehicleToAdd.ModelId = 3;
            vehicleToAdd.NewUsedId = 2;
            vehicleToAdd.BodyStyleId = 3;
            vehicleToAdd.InteriorColorId = 3;
            vehicleToAdd.ExteriorColorId = 2;
            vehicleToAdd.TransmissionId = 2;
            vehicleToAdd.DateAdded = DateTime.Today;
            vehicleToAdd.HasBeenSold = false;
            vehicleToAdd.IsFeatured = false;

            repo.Insert(vehicleToAdd);

            vehicleToAdd.Year = 2018;
            vehicleToAdd.Description = "TOADally awesome";
            vehicleToAdd.ImageFileName = "toadupdated.png";
            vehicleToAdd.MSRP = 1400;
            vehicleToAdd.Mileage = 21000;
            vehicleToAdd.VIN = "8635H";
            vehicleToAdd.SalePrice = 1000;
            vehicleToAdd.MakeId = 2;
            vehicleToAdd.ModelId = 2;
            vehicleToAdd.NewUsedId = 2;
            vehicleToAdd.BodyStyleId = 2;
            vehicleToAdd.InteriorColorId = 2;
            vehicleToAdd.ExteriorColorId = 1;
            vehicleToAdd.TransmissionId = 1;
            vehicleToAdd.DateAdded = DateTime.Today;
            vehicleToAdd.HasBeenSold = false;
            vehicleToAdd.IsFeatured = false;

            repo.Update(vehicleToAdd);

            var updatedVehicle = repo.GetById(3);
            Assert.AreEqual(2018, updatedVehicle.Year);
            Assert.AreEqual(1000, updatedVehicle.MSRP); 
            Assert.AreEqual(10, vehicleToAdd.VehicleId);

        }

        [Test]
        public void CanDeleteVehicle()
        {
            Vehicles vehicleToAdd = new Vehicles();
            var repo = new VehicleRepositoryADO();

            vehicleToAdd.Year = 2018;
            vehicleToAdd.Description = "TOADally awesome";
            vehicleToAdd.ImageFileName = "toad.png";
            vehicleToAdd.MSRP = 3400;
            vehicleToAdd.Mileage = 21000;
            vehicleToAdd.VIN = "8635H";
            vehicleToAdd.SalePrice = 18000;
            vehicleToAdd.MakeId = 3;
            vehicleToAdd.ModelId = 3;
            vehicleToAdd.NewUsedId = 2;
            vehicleToAdd.BodyStyleId = 3;
            vehicleToAdd.InteriorColorId = 3;
            vehicleToAdd.ExteriorColorId = 2;
            vehicleToAdd.TransmissionId = 2;
            vehicleToAdd.DateAdded = DateTime.Today;
            vehicleToAdd.HasBeenSold = false;
            vehicleToAdd.IsFeatured = false;

            repo.Insert(vehicleToAdd);

            var loaded = repo.GetById(3);
            Assert.IsNotNull(loaded);

            repo.Delete(3);
            loaded = repo.GetById(3);

            Assert.IsNull(loaded);


        }


        [Test]
        public void CanLoadOrder()
        {
            var repo = new OrderRepositoryADO();

            var order = repo.GetById(1);
            Assert.IsNotNull(order);
            Assert.AreEqual(1, order.OrderId);
            Assert.AreEqual(500, order.OrderTotal);
            Assert.AreEqual("Peach", order.CustomerName);
        }
        [Test]
        public void NUllOrder()
        {
            var repo = new OrderRepositoryADO();

            var order = repo.GetById(40);
            Assert.IsNull(order);

        }

        [Test]
        public void CanAddOrder()
        {
            Orders orderToAdd = new Orders();
            var repo = new OrderRepositoryADO();

            orderToAdd.UserId = "00000000 - 0000 - 0000 - 0000 - 000000000000";
            orderToAdd.OrderDate = DateTime.Today;
            orderToAdd.OrderTotal = 1600;
            orderToAdd.VehicleId = 2;
            orderToAdd.CustomerName = "Bowser";
            orderToAdd.CustomerPhone = "555-555-5555";
            orderToAdd.CustomerEmail = "StealPrincesses4lyfe@mushroomKingdom.com";
            orderToAdd.CustomerStreet1 = "666 Bone Palace";
            orderToAdd.CustomerStreet2 = string.Empty;
            orderToAdd.CustomerCity = "Koopa";
            orderToAdd.CustomerState = "Kingdom";
            orderToAdd.CustomerZipcode = 06660;
            orderToAdd.PurchaseTypeId = 1;



            repo.Insert(orderToAdd);

            Assert.AreEqual(3, orderToAdd.OrderId);

        }

        [Test]
        public void CanUpdateOrder()
        {
            Orders orderToAdd = new Orders();
            var repo = new OrderRepositoryADO();

            orderToAdd.UserId = "00000000 - 0000 - 0000 - 0000 - 000000000000";
            orderToAdd.OrderDate = DateTime.Today;
            orderToAdd.OrderTotal = 1600;
            orderToAdd.VehicleId = 2;
            orderToAdd.CustomerName = "Bowser";
            orderToAdd.CustomerPhone = "555-555-5555";
            orderToAdd.CustomerEmail = "StealPrincesses4lyfe@mushroomKingdom.com";
            orderToAdd.CustomerStreet1 = "666 Bone Palace";
            orderToAdd.CustomerStreet2 = string.Empty;
            orderToAdd.CustomerCity = "Koopa";
            orderToAdd.CustomerState = "Kingdom";
            orderToAdd.CustomerZipcode = 06660;
            orderToAdd.PurchaseTypeId = 1;

            repo.Insert(orderToAdd);

            orderToAdd.UserId = "00000000 - 0000 - 0000 - 0000 - 000000000000";
            orderToAdd.OrderDate = DateTime.Today;
            orderToAdd.OrderTotal = 1500;
            orderToAdd.VehicleId = 1;
            orderToAdd.CustomerName = "Bowser jr.";
            orderToAdd.CustomerPhone = "555-555-5555";
            orderToAdd.CustomerEmail = "StealPrincesses4lyfe@mushroomKingdom.com";
            orderToAdd.CustomerStreet1 = "666 Bone Palace";
            orderToAdd.CustomerStreet2 = string.Empty;
            orderToAdd.CustomerCity = "Koopa";
            orderToAdd.CustomerState = "Kingdom";
            orderToAdd.CustomerZipcode = 16660;
            orderToAdd.PurchaseTypeId = 2;

            repo.Update(orderToAdd);

            var updatedOrder = repo.GetById(3);
            Assert.AreEqual(1500, updatedOrder.OrderTotal);
            Assert.AreEqual(1, updatedOrder.VehicleId);
            Assert.AreEqual("Bowser jr.", updatedOrder.CustomerName);
            Assert.AreEqual("Koopa", updatedOrder.CustomerCity);
            Assert.AreEqual(2, updatedOrder.PurchaseTypeId);
            

        }

        [Test]
        public void CanDeleteOrder()
        {
            Orders orderToAdd = new Orders();
            var repo = new OrderRepositoryADO();

            orderToAdd.UserId = "00000000 - 0000 - 0000 - 0000 - 000000000000";
            orderToAdd.OrderDate = DateTime.Today;
            orderToAdd.OrderTotal = 1500;
            orderToAdd.VehicleId = 1;
            orderToAdd.CustomerName = "Bowser jr.";
            orderToAdd.CustomerPhone = "555-555-5555";
            orderToAdd.CustomerEmail = "StealPrincesses4lyfe@mushroomKingdom.com";
            orderToAdd.CustomerStreet1 = "666 Bone Palace";
            orderToAdd.CustomerStreet2 = string.Empty;
            orderToAdd.CustomerCity = "Koopa";
            orderToAdd.CustomerState = "Kingdom";
            orderToAdd.CustomerZipcode = 16660;
            orderToAdd.PurchaseTypeId = 2;

            repo.Insert(orderToAdd);

            var loaded = repo.GetById(3);
            Assert.IsNotNull(loaded);

            repo.Delete(3);
            loaded = repo.GetById(3);

            Assert.IsNull(loaded);


        }

        [Test]
        public void CanLoadSpecial()
        {
            var repo = new SpecialsRepositoryADO();

            var special = repo.GetById(1);
            Assert.IsNotNull(special);
            Assert.AreEqual(1, special.SpecialId);
            Assert.AreEqual("Flower Cup Champion", special.SpecialName);
            Assert.AreEqual("Grand champions of the flower cup get 0% financing for 12 months!", special.SpecialDescription);
        }
        [Test]
        public void NUllSpecial()
        {
            var repo = new SpecialsRepositoryADO();

            var special = repo.GetById(40);
            Assert.IsNull(special);

        }

        [Test]
        public void CanAddSpecial()
        {
            Specials specialToAdd = new Specials();
            var repo = new SpecialsRepositoryADO();

            specialToAdd.SpecialName = "Star Cup runner up";
            specialToAdd.SpecialDescription = "Free Starman with purchase";



            repo.Insert(specialToAdd);

            Assert.AreEqual(4, specialToAdd.SpecialId);

        }

        [Test]
        public void CanDeleteSpecial()
        {
            Specials specialToAdd = new Specials();
            var repo = new SpecialsRepositoryADO();

            specialToAdd.SpecialName = "Star Cup runner up";
            specialToAdd.SpecialDescription = "Free Starman with purchase";

            repo.Insert(specialToAdd);

            var loaded = repo.GetById(4);
            Assert.IsNotNull(loaded);

            repo.Delete(4);
            loaded = repo.GetById(4);

            Assert.IsNull(loaded);


        }

        [Test]
        public void CanLoadMake()
        {
            var repo = new MakeRepositoryADO();

            var make = repo.GetById(1);
            Assert.IsNotNull(make);
            Assert.AreEqual(1, make.MakeId);
            Assert.AreEqual("Baddieux", make.MakeName);
            
        }
        [Test]
        public void NullMake()
        {
            var repo = new MakeRepositoryADO();

            var make = repo.GetById(40);
            Assert.IsNull(make);

        }

        [Test]
        public void CanAddMake()
        {
            Make makeToAdd = new Make();
            var repo = new MakeRepositoryADO();

            makeToAdd.MakeName = "Boom";

            repo.Insert(makeToAdd);

            Assert.AreEqual(4, makeToAdd.MakeId);

        }

        [Test]
        public void CanLoadModel()
        {
            var repo = new ModelRepositoryADO();

            var model = repo.GetByModelId(1);
            Assert.IsNotNull(model);
            Assert.AreEqual(1, model.ModelId);
            Assert.AreEqual("Tooths", model.ModelName);
            Assert.AreEqual(1, model.MakeId);

        }
        [Test]
        public void NullModel()
        {
            var repo = new ModelRepositoryADO();

            var model = repo.GetByModelId(40);
            Assert.IsNull(model);

        }

        [Test]
        public void CanAddModel()
        {
            Model modelToAdd = new Model();
            var repo = new ModelRepositoryADO();

            modelToAdd.ModelName = "Boom";
            modelToAdd.MakeId = 3;

            repo.Insert(modelToAdd);

            Assert.AreEqual(10, modelToAdd.ModelId);

        }

        [Test]
        public void CanLoadBodyStyle()
        {
            var repo = new BodyStyleRepositoryADO();

            var body = repo.GetById(1);
            Assert.IsNotNull(body);
            Assert.AreEqual(1, body.BodyStyleId);
            Assert.AreEqual("ATV", body.BodyStyleName);
            

        }
        [Test]
        public void NullBodyStyle()
        {
            var repo = new BodyStyleRepositoryADO();

            var body = repo.GetById(40);
            Assert.IsNull(body);

        }

        [Test]
        public void CanLoadExteriorColor()
        {
            var repo = new ExteriorColorRepositoryADO();

            var ec = repo.GetById(1);
            Assert.IsNotNull(ec);
            Assert.AreEqual(1, ec.ExteriorColorId);
            Assert.AreEqual("Black", ec.ExteriorColorName);


        }
        [Test]
        public void NullExteriorColor()
        {
            var repo = new ExteriorColorRepositoryADO();

            var ec = repo.GetById(40);
            Assert.IsNull(ec);

        }

        [Test]
        public void CanLoadInteriorColor()
        {
            var repo = new InteriorColorRepositoryADO();

            var ic = repo.GetById(1);
            Assert.IsNotNull(ic);
            Assert.AreEqual(1, ic.InteriorColorId);
            Assert.AreEqual("Black", ic.InteriorColorName);


        }
        [Test]
        public void NullInteriorColor()
        {
            var repo = new InteriorColorRepositoryADO();

            var ic = repo.GetById(40);
            Assert.IsNull(ic);

        }

        [Test]
        public void CanLoadNewUsed()
        {
            var repo = new NewUsedRepositoryADO();

            var condition = repo.GetById(1);
            Assert.IsNotNull(condition);
            Assert.AreEqual(1, condition.NewUsedId);
            Assert.AreEqual("New", condition.NewUsedName);


        }
        [Test]
        public void NullNewUsed()
        {
            var repo = new NewUsedRepositoryADO();

            var condition = repo.GetById(40);
            Assert.IsNull(condition);

        }

        [Test]
        public void CanLoadPurchaseType()
        {
            var repo = new PurchaseTypeRepositoryADO();

            var pt = repo.GetById(1);
            Assert.IsNotNull(pt);
            Assert.AreEqual(1, pt.PurchaseTypeId);
            Assert.AreEqual("Financing", pt.PurchaseTypeName);


        }
        [Test]
        public void NullPurchaseType()
        {
            var repo = new PurchaseTypeRepositoryADO();

            var pt = repo.GetById(40);
            Assert.IsNull(pt);

        }

        [Test]
        public void CanLoadTransmission()
        {
            var repo = new TransmissionRepositoryADO();

            var transmission = repo.GetById(1);
            Assert.IsNotNull(transmission);
            Assert.AreEqual(1, transmission.TransmissionId);
            Assert.AreEqual("Automatic", transmission.TransmissionName);


        }
        [Test]
        public void NullTransmission()
        {
            var repo = new TransmissionRepositoryADO();

            var transmission = repo.GetById(40);
            Assert.IsNull(transmission);

        }

        [Test]
        public void CanLoadVehicleNew()
        {
            var repo = new VehicleRepositoryADO();

            var vehicle = repo.GetAllNew();
            Assert.IsNotNull(vehicle);
            Assert.AreEqual(4, vehicle.Count);
           
        }

        [Test]
        public void CanLoadVehicleUsed()
        {
            var repo = new VehicleRepositoryADO();

            var vehicle = repo.GetAllUsed();
            Assert.IsNotNull(vehicle);
            Assert.AreEqual(5, vehicle.Count);

        }

        [Test]
        public void CanLoadFeatured()
        {
            var repo = new VehicleRepositoryADO();

            var vehicle = repo.GetAllFeatured();
            Assert.IsNotNull(vehicle);
            Assert.AreEqual(5, vehicle.Count());

        }


        [Test]
        public void CanContactUs()
        {
            ContactUs contact = new ContactUs();
            var repo = new ContactUsRepositoryADO();

            contact.Name = "Boom";
            contact.Email = "Bobomb@badguys.net";
            contact.Phone = "555-555-5555";
            contact.Message = "I want... BOOM!";

            repo.Insert(contact);

            Assert.AreEqual(2, contact.ContactUsId);
            Assert.AreEqual("Boom", contact.Name);

        }

    }
}
