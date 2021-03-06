﻿using Microsoft.Owin;
using Owin;
using ITMatcherWeb.DataContexts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ITMatcherWeb.Models;
using System.Data.Entity;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(ITMatcherWeb.Startup))]
namespace ITMatcherWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
        }

        private void CreateRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<User>(new UserStore<User>(context));

            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("Admin1"))
            {
                // first we create Admin rool   
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin1";
                roleManager.Create(role);
            }

            // creating Creating Manager role    
            if (!roleManager.RoleExists("Admin2"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin2";
                roleManager.Create(role);

            }

            // creating Creating Admin3 role    
            if (!roleManager.RoleExists("Admin3"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin3";
                roleManager.Create(role);

                var user = new User();
                user.UserName = "admin@admin.dk";
                user.Email = "admin@admin.dk";

                string userPWD = "asdasd1";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin  
                if (chkUser.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, "Admin3");
                }
            }



            if (!roleManager.RoleExists("Consultant"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Consultant";
                roleManager.Create(role);

            }
        }
    }
}
