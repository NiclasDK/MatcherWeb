using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ITMatcherWeb.DataContext
{
    public class JobExperienceDb : DbContext
    {
        public JobExperienceDb()
            : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<ITMatcherWeb.Models.JobExperience> JobExperiences { get; set; }
    }
}