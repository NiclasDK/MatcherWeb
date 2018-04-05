using ITMatcherWeb.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ITMatcherWeb.DataContexts
{
    public class SubjectDb : DbContext
    {
        public virtual DbSet<Subject> Subjects{ get; set; }

        public SubjectDb() : base("DefaultConnection")
        {

        }
    }
}