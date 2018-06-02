using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITMatcherWeb.Models
{
    public class Environment
    {
        public int EnvironmentId { get; set; }
        public string EnvironmentName { get; set; }
        public Boolean IsAccepted { get; set; }
        public virtual JobExperience JobExperience { get; set;}
        public int JobExperienceId { get; set; }
    }
}