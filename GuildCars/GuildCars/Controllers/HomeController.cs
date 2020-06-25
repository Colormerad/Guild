using GuildCars.Data.Interfaces;
using GuildCars.Factories;
using GuildCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeIndexViewModel viewModel = new HomeIndexViewModel();
            viewModel.featuredVehicles = VehicleRepositoryFactory.GetRepository().GetAllFeatured();
            viewModel.specials = SpecialRepositoryFactory.GetRepository().GetAll();

            //var model = VehicleRepositoryFactory.GetRepository().GetAllFeatured();
            return View(viewModel);
        }

        public ActionResult Specials()
        {
            SpecialsViewModel viewModel = new SpecialsViewModel();
            viewModel.specials = SpecialRepositoryFactory.GetRepository().GetAll();

            return View(viewModel);
        }

 
        [HttpGet]
        public ActionResult Contactus(string VIN = null)
        {
            ContactUsViewModel viewModel = new ContactUsViewModel();
            if (VIN != null)
            {
                viewModel.contactus = new Models.Tables.ContactUs();
                viewModel.contactus.Message = VIN;
            }
            
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Contactus(ContactUsViewModel viewModel)
        {
            
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            if (viewModel.contactus.Email == null)
            {
                viewModel.contactus.Email = "";
            }
            if (viewModel.contactus.Phone == null)
            {
                viewModel.contactus.Phone = "";
            }
            IContactUsRepository repository = ContactUsRepositoryFactory.GetRepository();
            repository.Insert(viewModel.contactus);
            return RedirectToAction("Contactus", "Home");
        }
    }
}