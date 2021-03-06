﻿using System;
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
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Employment date")]
        public DateTime? DateOfEmployment { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Leave date")]
        public DateTime? DateOfExit { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Environment> Environments { get; set; }
        public virtual ICollection<Title> Titles { get; set; }
        public virtual User ApplicationUser { get; set; }
        public bool IsAccepted { get; set; }

        public JobExperience()
        {
            this.Environments = new HashSet<Models.Environment>();
            this.Subjects = new HashSet<Subject>();
            this.Titles = new HashSet<Title>();
        }
    }
}