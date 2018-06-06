using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITMatcherWeb.Models
{
    public class Business
    {
        [Key]
        public int BusinessId { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual User ApplicationUser { get; set; }
        public bool IsAccepted { get; set; }
    }
}