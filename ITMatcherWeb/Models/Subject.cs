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
        public PercievedLevelOfSkill PercievedLevelOfSkill { get; set; }
        public bool IsAccepted{ get; set; }
        //public int? JobExperienceId { get; set; }
        //Navigational prop
        public virtual ICollection<JobExperience> JobExperiences { get; set; }

        public Subject()
        {
            this.JobExperiences = new HashSet<JobExperience>();
        }
    }

    public enum PercievedLevelOfSkill
    {
        Basic,
        Good,
        Excellent
    }
}