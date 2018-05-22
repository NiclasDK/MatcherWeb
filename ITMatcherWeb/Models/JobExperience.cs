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
        [Required]
        public string Employer { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Employment date")]
        public DateTime? DateOfEmployment { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Leave date")]
        public DateTime? DateOfExit { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Environment> Environments { get; set; }
        public virtual ICollection<Title> Titles { get; set; }
        public virtual User ApplicationUser { get; set; }
    }
}