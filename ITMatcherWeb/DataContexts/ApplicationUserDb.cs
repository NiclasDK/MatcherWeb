using ITMatcherWeb.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ITMatcherWeb.DataContexts
{

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
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<Clause> Clauses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
            .HasMany(u => u.Businesses);

            modelBuilder.Entity<Bulletin>()
            .HasOptional(b => b.Picture)
            .WithRequired(p => p.Bulletin)
            .WillCascadeOnDelete(true);

            modelBuilder.Entity<JobExperience>()
            .HasMany<Models.Environment>(s => s.Environments)
            .WithMany(e => e.JobExperiences)
            .Map(cs =>
            {
                cs.MapLeftKey("JobExperienceId");
                cs.MapRightKey("EnvironmentId");
                cs.ToTable("JobexpEnv");
            });

            modelBuilder.Entity<JobExperience>()
            .HasMany<Models.Subject>(s => s.Subjects)
            .WithMany(e => e.JobExperiences)
            .Map(cs =>
            {
                cs.MapLeftKey("JobExperienceId");
                cs.MapRightKey("SubjectId");
                cs.ToTable("JobexpSubj");
            });

            modelBuilder.Entity<JobExperience>()
            .HasMany<Models.Title>(s => s.Titles)
            .WithMany(e => e.JobExperiences)
            .Map(cs =>
            {
                cs.MapLeftKey("JobExperienceId");
                cs.MapRightKey("TitleId");
                cs.ToTable("JobexpTit");
            });

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

            modelBuilder.Entity<User>()
            .HasMany(u => u.Clauses)
            .WithRequired(c => c.ApplicationUser)
            .WillCascadeOnDelete(true);

            modelBuilder.Entity<UserLanguages>()
                .HasKey(ul => new { ul.LanguageId, ul.UserId });

            modelBuilder.Entity<UserLanguages>()
                .HasRequired(ul => ul.User)
                .WithMany(ul => ul.Languages)
                .HasForeignKey(pl => pl.UserId);

            modelBuilder.Entity<UserLanguages>()
                .HasRequired(ul => ul.Language)
                .WithMany(ul => ul.Users)
                .HasForeignKey(ul => ul.LanguageId);

            /*modelBuilder.Entity<User>()
            .HasMany<Models.Language>(s => s.Languages)
            .WithMany(e => e.Users)
            .Map(cs =>
            {
                cs.MapLeftKey("Id");
                cs.MapRightKey("LanguageId");
                cs.ToTable("UserLanguage");
            });*/

            modelBuilder.Entity<User>()
            .HasMany(u => u.Certificates)
            .WithRequired(c => c.ApplicationUser)
            .WillCascadeOnDelete(true);

        }

        public ApplicationDbContext() : base("DefaultConnection")
        {

        }

        internal static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<ITMatcherWeb.Models.Business> Businesses { get; set; }
    }
}