using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITMatcherWeb.Models
{
    public class Clause
    {
        public int clauseId { get; set; }
        public string workplace { get; set; }
        [DataType(DataType.Date)]
        public DateTime endDate { get; set; }
        public virtual User ApplicationUser { get; set; }
    }
}