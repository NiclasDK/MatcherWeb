using ITMatcherWeb.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ITMatcherWeb.DataContexts
{
    public class IdentityDb : IdentityDbContext<ApplicationUser>
    {


        public IdentityDb() : base("DefaultConnection")
        {

        }

    }
}