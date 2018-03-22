using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITMatcherWeb.Models
{
    public class ConsultantExperience
    {
        String Employer { get; set; }
        DateTime DateOfEmployment { get; set; }
        DateTime DateOfExit { get; set; }
        List<Subject> Subjects { get; set; }



    }

    internal class Subject
    {
        String Name { get; set; }
        DateTime StartTime { get; set; }
        DateTime DateTime { get; set; }
        int PercievedLevelOfSkill { get; set; }
    }


}