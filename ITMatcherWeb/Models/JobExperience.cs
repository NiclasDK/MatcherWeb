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
        [Key]
        public int JobExperienceId { get; set; }
        public string Employer { get; set; }
        public DateTime? DateOfEmployment { get; set; }
        public DateTime? DateOfExit { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual User ApplicationUser { get; set; }
    }
}