using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITMatcherWeb.Models
{
    public class JobExperience
    {
        public string JobExperienceId { get; set; }
        public string Employer { get; set; }
        public DateTime? DateOfEmployment { get; set; }
        public DateTime? DateOfExit { get; set; }
        public List<Subject> Subjects { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int ApplicationUserId { get; set; }

    }
}