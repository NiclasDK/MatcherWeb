using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITMatcherWeb.Models
{
    public class Title
    {
        public int TitleId { get; set; }
        public string TitleName { get; set; }
        public Boolean IsAccepted { get; set; } = false;
        //public JobExperience JobExperience { get; set; }
        public virtual ICollection<JobExperience> JobExperiences { get; set; }
        //public int? JobExperienceId { get; set; }
        
        public Title()
        {
            this.JobExperiences = new HashSet<JobExperience>();
        }

    }
}