using GuildCars.Data.Interfaces;
using GuildCars.Factories;
using GuildCars.Models;
using GuildCars.Models.Tables;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Vehicles()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddVehicle()
        {
            AddEditVehicleViewModel viewModel = new AddEditVehicleViewModel();
            viewModel.vehicle = new Vehicles();
            viewModel.makesList = viewModel.GenerateMakesList(MakesRepositoryFactory.GetRepository().GetAll());
            viewModel.newUsedsList = viewModel.GenerateNewUsedList(NewUsedRepositoryFactory.GetRepository().GetAll());
            viewModel.bodyStylesList = viewModel.GenerateBodyStylesList(BodyStyleRepositoryFactory.GetRepository().GetAll());
            viewModel.transmissionsList = viewModel.GenerateTransmissionsList(TransmissionRepositoryFactory.GetRepository().GetAll());
            viewModel.exteriorColorsList = viewModel.GenerateExteriorColorList(ExteriorColorRepositoryFactory.GetRepository().GetAll());
            viewModel.interiorColorsList = viewModel.GenerateInteriorColorList(InteriorColorRepositoryFactory.GetRepository().GetAll());

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddVehicle(AddEditVehicleViewModel viewModel, HttpPostedFileBase file)
        {
            IVehicleRepository repository = VehicleRepositoryFactory.GetRepository();
            if (!ModelState.IsValid)
            {
                
                viewModel.vehicle = new Vehicles();
                viewModel.makesList = viewModel.GenerateMakesList(MakesRepositoryFactory.GetRepository().GetAll());
                viewModel.newUsedsList = viewModel.GenerateNewUsedList(NewUsedRepositoryFactory.GetRepository().GetAll());
                viewModel.bodyStylesList = viewModel.GenerateBodyStylesList(BodyStyleRepositoryFactory.GetRepository().GetAll());
                viewModel.transmissionsList = viewModel.GenerateTransmissionsList(TransmissionRepositoryFactory.GetRepository().GetAll());
                viewModel.exteriorColorsList = viewModel.GenerateExteriorColorList(ExteriorColorRepositoryFactory.GetRepository().GetAll());
                viewModel.interiorColorsList = viewModel.GenerateInteriorColorList(InteriorColorRepositoryFactory.GetRepository().GetAll());

                return View(viewModel);
            }

            if (file == null)
            {
                
                viewModel.vehicle.ImageFileName = viewModel.vehicle.ImageFileName;

            }
            else
            {
                viewModel.vehicle.ImageFileName = file.FileName;
                file.SaveAs(HttpContext.Server.MapPath("~/Images/") + file.FileName);
            }

            viewModel.vehicle.DateAdded = DateTime.Now;
            repository.Insert(viewModel.vehicle);


            return RedirectToAction("EditVehicle/" + viewModel.vehicle.VehicleId, "Admin");
        }

        [HttpGet]
        public ActionResult EditVehicle(int id)
        {
            var repo = VehicleRepositoryFactory.GetRepository();
            AddEditVehicleViewModel viewModel = new AddEditVehicleViewModel();
            viewModel.vehicle = repo.GetById(id);


            viewModel.makesList = viewModel.GenerateMakesList(MakesRepositoryFactory.GetRepository().GetAll());
            viewModel.newUsedsList = viewModel.GenerateNewUsedList(NewUsedRepositoryFactory.GetRepository().GetAll());
            viewModel.bodyStylesList = viewModel.GenerateBodyStylesList(BodyStyleRepositoryFactory.GetRepository().GetAll());
            viewModel.transmissionsList = viewModel.GenerateTransmissionsList(TransmissionRepositoryFactory.GetRepository().GetAll());
            viewModel.exteriorColorsList = viewModel.GenerateExteriorColorList(ExteriorColorRepositoryFactory.GetRepository().GetAll());
            viewModel.interiorColorsList = viewModel.GenerateInteriorColorList(InteriorColorRepositoryFactory.GetRepository().GetAll());

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditVehicle(AddEditVehicleViewModel viewModel, HttpPostedFileBase file)
        {
            IVehicleRepository repository = VehicleRepositoryFactory.GetRepository();

            if (file != null)
            {
                viewModel.vehicle.ImageFileName = file.FileName;
                file.SaveAs(HttpContext.Server.MapPath("~/Images/") + file.FileName);
            }

            if (!ModelState.IsValid)
            {
                viewModel.makesList = viewModel.GenerateMakesList(MakesRepositoryFactory.GetRepository().GetAll());
                viewModel.newUsedsList = viewModel.GenerateNewUsedList(NewUsedRepositoryFactory.GetRepository().GetAll());
                viewModel.bodyStylesList = viewModel.GenerateBodyStylesList(BodyStyleRepositoryFactory.GetRepository().GetAll());
                viewModel.transmissionsList = viewModel.GenerateTransmissionsList(TransmissionRepositoryFactory.GetRepository().GetAll());
                viewModel.exteriorColorsList = viewModel.GenerateExteriorColorList(ExteriorColorRepositoryFactory.GetRepository().GetAll());
                viewModel.interiorColorsList = viewModel.GenerateInteriorColorList(InteriorColorRepositoryFactory.GetRepository().GetAll());

                return View(viewModel);
            }

            viewModel.vehicle.DateAdded = viewModel.vehicle.DateAdded;
            repository.Update(viewModel.vehicle);


            return RedirectToAction("EditVehicle/" + viewModel.vehicle.VehicleId, "Admin");
        }
        public ActionResult DeleteVehicle(int id)
        {
            AddEditVehicleViewModel viewModel = new AddEditVehicleViewModel();
            IVehicleRepository repository = VehicleRepositoryFactory.GetRepository();
            repository.Delete(id);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Users()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            UserManager<ApplicationUser> userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            RoleManager<IdentityRole> roleMgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            List<ApplicationUser> users = userMgr.Users.ToList();

            foreach (var user in users)
            {
                //Get First Role For User
                var roleid = user.Roles.FirstOrDefault();

                if (roleid != null)
                {
                    //Get Role That Matches User Role
                    IdentityRole identityRole = roleMgr.Roles.Where(x => x.Id == roleid.RoleId).FirstOrDefault();

                    //Capture Name of IdentityRole
                    string roleName = identityRole.Name;

                    //Assign User's String Role with the Name for Webpage
                    user.Role = roleName;
                }
                else
                {
                    user.Role = "None";
                }




            }

            return View(users);
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            EditUserViewModel viewModel = new EditUserViewModel();
            ApplicationDbContext context = new ApplicationDbContext();

            viewModel.user = new ApplicationUser();
            viewModel.rolelist = viewModel.GenerateIdentityRolesList(context.Roles.ToList());

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult AddUser(EditUserViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                ApplicationDbContext context2 = new ApplicationDbContext();
                viewModel.user = new ApplicationUser();
                viewModel.rolelist = viewModel.GenerateIdentityRolesList(context2.Roles.ToList());

                return View(viewModel);
            }

            ApplicationDbContext context = new ApplicationDbContext();
            UserManager<ApplicationUser> userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            RoleManager<IdentityRole> roleMgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            IdentityRole selectedRole = roleMgr.Roles.ToList().Where(x => x.Id == viewModel.RoleId).FirstOrDefault();

            ApplicationUser user = new ApplicationUser
            {
                UserName = viewModel.user.Email,
                Email = viewModel.user.Email,
                FirstName = viewModel.user.FirstName,
                LastName = viewModel.user.LastName

            };
            userMgr.Create(user, viewModel.Password);
            userMgr.AddToRole(user.Id, selectedRole.Name);

            return RedirectToAction("Users", "Admin");
        }
        [HttpGet]
        public ActionResult EditUser(string id)
        {
            EditUserViewModel viewModel = new EditUserViewModel();

            ApplicationDbContext context = new ApplicationDbContext();

            ApplicationUser user = context.Users.Where(x => x.Id == id).FirstOrDefault();
            

            viewModel.user = user;
            viewModel.rolelist = viewModel.GenerateIdentityRolesList(context.Roles.ToList());

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult EditUser(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return View(model);
            }
            ApplicationDbContext context = new ApplicationDbContext();
            ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            ApplicationUser updatedUser = context.Users.ToList().Where(x => x.Id == model.user.Id).FirstOrDefault();
            IdentityRole newRole = context.Roles.ToList().Where(x => x.Id == model.RoleId).FirstOrDefault();
            string oldRoleID = updatedUser.Roles.FirstOrDefault().RoleId;
            string oldRoleName = context.Roles.Where(x => x.Id == oldRoleID).FirstOrDefault().Name;

            //Update Fields
            updatedUser.FirstName = model.user.FirstName;
            updatedUser.LastName = model.user.LastName;
            updatedUser.Email = model.user.Email;
            updatedUser.UserName = model.user.Email;

            updatedUser.PasswordHash = userManager.PasswordHasher.HashPassword(model.Password);

            ////Update Roles
            if (updatedUser.Roles.Count > 0)
            {
                userManager.RemoveFromRole(updatedUser.Id, oldRoleName);
            }

            userManager.AddToRole(updatedUser.Id, newRole.Name);
            userManager.Update(updatedUser);

            return RedirectToAction("Users", "Admin");

        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Makes()
        {
            MakesViewModel viewModel = new MakesViewModel();
            viewModel.makes = MakesRepositoryFactory.GetRepository().GetAll();
            ApplicationDbContext context = new ApplicationDbContext();
            UserManager<ApplicationUser> userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            foreach (var item in viewModel.makes)
            {
                item.UserId = userMgr.Users.Where(x => x.Id == item.UserId).FirstOrDefault().UserName;
            }
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Makes(MakesViewModel viewModel)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            UserManager<ApplicationUser> userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            IMakeRepository repository = MakesRepositoryFactory.GetRepository();
            viewModel.makes = repository.GetAll();
            foreach (var item in viewModel.makes)
            {
                item.UserId = userMgr.Users.Where(x => x.Id == item.UserId).FirstOrDefault().UserName;
            }

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
        
            viewModel.make.UserId = User.Identity.GetUserId();
            viewModel.make.AddedDate = DateTime.Now;
            repository.Insert(viewModel.make);
            return View(viewModel);
        }
        [HttpGet]
        public ActionResult Models()
        {
            ModelsViewModel viewModel = new ModelsViewModel();
            ApplicationDbContext context = new ApplicationDbContext();
            UserManager<ApplicationUser> userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            List<Model> models = ModelsRepositoryFactory.GetRepository().GetAll();
            List<Make> makes = MakesRepositoryFactory.GetRepository().GetAll();
            List<ModelShortView> modelShortViews = new List<ModelShortView>();
            foreach (var m in models)
            {
                ModelShortView item = new ModelShortView();
                item.ModelId = m.ModelId;
                item.ModelName = m.ModelName;
                item.UserId = userMgr.Users.Where(x => x.Id == m.UserId).FirstOrDefault().UserName;
                item.AddedDate = m.AddedDate;
                Make make = makes.Where(x => x.MakeId == m.MakeId).FirstOrDefault();
                item.MakeName = make.MakeName;
                item.MakeId = make.MakeId;
                modelShortViews.Add(item);
            }
            viewModel.makesList = viewModel.GenerateMakesList(MakesRepositoryFactory.GetRepository().GetAll());
            viewModel.models = modelShortViews;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Models(ModelsViewModel viewModel)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            UserManager<ApplicationUser> userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!ModelState.IsValid)
            {
                List<Model> models = ModelsRepositoryFactory.GetRepository().GetAll();
                List<Make> makes = MakesRepositoryFactory.GetRepository().GetAll();
                List<ModelShortView> modelShortViews = new List<ModelShortView>();
                foreach (var m in models)
                {
                    ModelShortView item = new ModelShortView();
                    item.ModelId = m.ModelId;
                    item.ModelName = m.ModelName;
                    item.UserId = userMgr.Users.Where(x => x.Id == m.UserId).FirstOrDefault().UserName;
                    item.AddedDate = m.AddedDate;
                    Make make = makes.Where(x => x.MakeId == m.MakeId).FirstOrDefault();
                    item.MakeName = make.MakeName;
                    item.MakeId = make.MakeId;
                    modelShortViews.Add(item);
                }
                viewModel.makesList = viewModel.GenerateMakesList(MakesRepositoryFactory.GetRepository().GetAll());
                viewModel.models = modelShortViews;
                return View(viewModel);
            }
            IModelRepository repository = ModelsRepositoryFactory.GetRepository();
            Model modeltoAdd = new Model();
            modeltoAdd.ModelName = viewModel.modelName;
            modeltoAdd.MakeId = int.Parse(viewModel.makeId);
            modeltoAdd.UserId = User.Identity.GetUserId();
            modeltoAdd.AddedDate = DateTime.Now;
            repository.Insert(modeltoAdd);

            return RedirectToAction("Models", "Admin");
        }
        [HttpGet]
        public ActionResult Specials()
        {
            SpecialsViewModel viewModel = new SpecialsViewModel();
            viewModel.specials = SpecialRepositoryFactory.GetRepository().GetAll();
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Specials(SpecialsViewModel viewModel, HttpPostedFileBase file)
        {
            viewModel.special.SpecialImageFileName = file.FileName;
            file.SaveAs(HttpContext.Server.MapPath("~/Images/") + file.FileName);
            if (!ModelState.IsValid)
            {
                viewModel.specials = SpecialRepositoryFactory.GetRepository().GetAll();
                return View(viewModel);
            }
            ISpecialsRepository repository = SpecialRepositoryFactory.GetRepository();
            viewModel.special.SpecialImageFileName = file.FileName;
            file.SaveAs(HttpContext.Server.MapPath("~/Images/") + file.FileName);
            repository.Insert(viewModel.special);
            viewModel.specials = SpecialRepositoryFactory.GetRepository().GetAll();
            return RedirectToAction("Specials", "Admin");
        }

        public ActionResult DeleteSpecial(int id)
        {
            SpecialsViewModel viewModel = new SpecialsViewModel();
            ISpecialsRepository repository = SpecialRepositoryFactory.GetRepository();
            repository.Delete(id);

            return RedirectToAction("Specials", "Admin");
        }
    }
}