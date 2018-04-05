using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITMatcherWeb.Models
{
    public class Certificate
    {
        [Key]
        public string CertificateId { get; set; }
        [Display(Name = "Certification-date")]
        public DateTime? DateOfCertification { get; set; }
        public string Name { get; set; }
        [Display(Name = "Name of certifier")]
        public string CertificationProvider { get; set;}
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}