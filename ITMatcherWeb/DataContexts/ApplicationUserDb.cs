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
        public virtual DbSet<Bulletin> Bulletins { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Models.Environment> Environments { get; set; }
        public virtual DbSet<Title> Titles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<JobExperience>()
            .HasMany(j => j.Subjects);

            modelBuilder.Entity<Bulletin>()
            .HasOptional(b => b.Picture)
            .WithRequired(p => p.Bulletin);

            //Creates relation between user and jobexperiences. 
            //User is required for jobExperience to exist.
            //If user is deleted, all JobExperiences will be deleted.
            modelBuilder.Entity<User>()
            .HasMany(u => u.JobExperiences)
            .WithRequired(j => j.ApplicationUser)
            .WillCascadeOnDelete(true);

            modelBuilder.Entity<User>()
            .HasMany(u => u.Educations)
            .WithRequired(e => e.ApplicationUser)
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