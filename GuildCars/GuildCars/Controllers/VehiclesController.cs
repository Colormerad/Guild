using GuildCars.Factories;
using GuildCars.Models;
using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.Controllers
{
    public class VehiclesController : Controller
    {
        // GET: Vehicles
        public ActionResult Details(int id)
        {
            var repo = VehicleRepositoryFactory.GetRepository();
            var ViewModel = repo.GetVehicleDetails(id);

            return View(ViewModel);
        }

        [HttpGet]
        public ActionResult New()
        {
            VehicleSearchViewModel viewModel = new VehicleSearchViewModel();


            return View(viewModel);
        }
     

        public ActionResult Used()
        {
            VehicleSearchViewModel viewModel = new VehicleSearchViewModel();


            return View(viewModel);
        }

    }
}