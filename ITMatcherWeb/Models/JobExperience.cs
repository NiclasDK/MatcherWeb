using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITMatcherWeb.Models
{
    public class JobExperience
    {
        String Id { get; set; }
        string Employer { get; set; }
        DateTime DateOfEmployment { get; set; }
        DateTime DateOfExit { get; set; }
        List<Subject> Subjects { get; set; }
    }
}