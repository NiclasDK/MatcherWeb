using ITMatcherWeb.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ITMatcherWeb.DataContexts
{
    //ApplicationUserDb
    public class ApplicationDbContext : IdentityDbContext<User>
    {

        public virtual DbSet<JobExperience> JobExperiences { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Certificate> Certificates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
            .HasMany(u => u.JobExperiences)
            .WithRequired(j => j.ApplicationUser)
            .WillCascadeOnDelete(true);
        }

        public ApplicationDbContext() : base("DefaultConnection")
        {

        }

        internal static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}