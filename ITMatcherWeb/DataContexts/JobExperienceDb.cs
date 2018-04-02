using ITMatcherWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ITMatcherWeb.DataContexts
{
    public class JobExperienceDb : DbContext
    {
        public virtual DbSet<JobExperience> JobExperiences { get; set; }

        public JobExperienceDb() : base("DefaultConnection")
        {

        }
    }
}