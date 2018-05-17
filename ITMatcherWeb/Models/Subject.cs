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
        public string Name { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public PercievedLevelOfSkill PercievedLevelOfSkill { get; set; }
        public int JobExperienceId { get; set; }
    }

    public enum PercievedLevelOfSkill
    {
        Basic,
        Good,
        Excellent,
        native,
    }
}