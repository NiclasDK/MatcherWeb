using ITMatcherWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ITMatcherWeb.DataContext.IdentityMigrations
{
    public class SubjectDb : DbContext
    {

        public DbSet<Subject> Subjects { get; set; }

        public SubjectDb()
            : base("DefaultConnection")
        {
        }
    }
}