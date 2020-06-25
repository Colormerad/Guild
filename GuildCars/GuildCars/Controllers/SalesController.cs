using GuildCars.Data.Interfaces;
using GuildCars.Factories;
using GuildCars.Models;
using GuildCars.Models.Tables;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.Controllers
{
    public class SalesController : Controller
    {
        [Authorize(Roles = "Sales")]
        // GET: Sales
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Purchase(int id)
        {
            OrdersViewModel viewModel = new OrdersViewModel();

            //List<Orders> orders = OrdersRepositoryFactory.GetRepository().GetAll();
            var repo = VehicleRepositoryFactory.GetRepository();
            
            viewModel.vehicleDetail = repo.GetVehicleDetails(id);
            viewModel.PurchaseTypeList = viewModel.GeneratePurchaseTypeList(PurchaseTypeFactory.GetRepository().GetAll());
            
            
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Purchase(OrdersViewModel viewModel)
        {
            IOrderRepository orderRepository = OrdersRepositoryFactory.GetRepository();
            IVehicleRepository vehicleRepository = VehicleRepositoryFactory.GetRepository();
            if (viewModel.order.CustomerStreet2 == null)
            {
                viewModel.order.CustomerStreet2 = " ";
            }
            if (!ModelState.IsValid)
            {
                viewModel.vehicleDetail = vehicleRepository.GetVehicleDetails(viewModel.vehicleDetail.VehicleId);
                viewModel.PurchaseTypeList = viewModel.GeneratePurchaseTypeList(PurchaseTypeFactory.GetRepository().GetAll());
                return View(viewModel);
            }

            
            viewModel.order.VehicleId = viewModel.vehicleDetail.VehicleId;
            viewModel.order.UserId = User.Identity.GetUserId();
            viewModel.order.OrderDate = DateTime.Now;
           
            orderRepository.Insert(viewModel.order);
            Vehicles soldVehicle = vehicleRepository.GetById(viewModel.vehicleDetail.VehicleId);
            soldVehicle.HasBeenSold = true;
            vehicleRepository.Update(soldVehicle);


            return RedirectToAction("Index", "Sales");
        }
    }
}