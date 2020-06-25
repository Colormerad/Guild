using GuildCars.Factories;
using GuildCars.Models;
using GuildCars.Models.Queries;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.Controllers
{
    public class ReportsController : Controller
    {
        [Authorize(Roles = "Admin")]
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Sales()
        {
            SalesReportQueryViewModel viewModel = new SalesReportQueryViewModel();
            ApplicationDbContext context = new ApplicationDbContext();
            UserManager<ApplicationUser> userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            viewModel.reportsList = viewModel.GenerateUsersList(userMgr.Users.ToList());
            return View(viewModel);
        }
        public ActionResult Inventory()
        {
            InventoryReportViewModel viewModel = new InventoryReportViewModel();

            viewModel.newInventoryReports = InventoryReportRepositoryFactory.GetRepository().GetAllNew();
            viewModel.usedInventoryReports = InventoryReportRepositoryFactory.GetRepository().GetAllUsed();

            return View(viewModel);
        }
    }
}