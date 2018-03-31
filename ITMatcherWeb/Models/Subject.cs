using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITMatcherWeb.Models
{
    public class Subject
    {
        public string Id { get; set; }
        string Name { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int PercievedLevelOfSkill { get; set; }
    }
}