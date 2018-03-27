using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITMatcherWeb.Models
{
    public class Subject
    {
        string Id { get; set; }
        String Name { get; set; }
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
        int PercievedLevelOfSkill { get; set; }
    }
}