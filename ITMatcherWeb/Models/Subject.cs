using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITMatcherWeb.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        [Required]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime? StartTime { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndTime { get; set; }
        [Required]
        public virtual JobExperience JobExperience { get; set; }
        public PercievedLevelOfSkill PercievedLevelOfSkill { get; set; }
        public int JobExperienceId { get; set; }
    }

    public enum PercievedLevelOfSkill
    {
        Basic,
        Good,
        Excellent
    }
}