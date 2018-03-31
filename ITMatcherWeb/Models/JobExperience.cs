using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITMatcherWeb.Models
{
    public class JobExperience
    {
        public string Id { get; set; }
        public string Employer { get; set; }
        public DateTime? DateOfEmployment { get; set; }
        public DateTime? DateOfExit { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}