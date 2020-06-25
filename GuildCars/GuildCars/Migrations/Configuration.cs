namespace GuildCars.Migrations
{
    using GuildCars.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GuildCars.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }


        protected override void Seed(ApplicationDbContext context)
        {
            // Load the user and role managers with our custom models
            UserManager<ApplicationUser> userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            RoleManager<IdentityRole> roleMgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // have we loaded roles already?
            if (!roleMgr.RoleExists("admin"))
            {
                roleMgr.Create(new IdentityRole() { Name = "Admin" });
                roleMgr.Create(new IdentityRole() { Name = "Sales" });
                roleMgr.Create(new IdentityRole() { Name = "Disabled" });
            }


            // create the admin role

            // create the default user
            ApplicationUser user = new ApplicationUser
            {
                UserName = "admin",
                Email = "admin@mushroomracers.com",
                FirstName = "Mario",
                LastName = "Mario"
            };
            ApplicationUser sales1 = new ApplicationUser
            {
                UserName = "sales",
                Email = "sales@mushroomracers.com",
                FirstName = "Luigi",
                LastName = "Mario"
            };

            // create the user with the manager class
            userMgr.Create(user, "admin123");
            userMgr.Create(sales1, "sales123");

            // add the user to the admin role
            userMgr.AddToRole(user.Id, "Admin");
            userMgr.AddToRole(sales1.Id, "Sales");

        }

    }
}
