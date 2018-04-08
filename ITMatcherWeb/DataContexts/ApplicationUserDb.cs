using ITMatcherWeb.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ITMatcherWeb.DataContexts
{
    public class ApplicationUserDb : IdentityDbContext<Users>
    {

        public virtual DbSet<JobExperience> JobExperiences { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Certificate> Certificates { get; set; }

        public ApplicationUserDb() : base("DefaultConnection")
        {

        }

        internal static ApplicationUserDb Create()
        {
            return new ApplicationUserDb();
        }

    }
}