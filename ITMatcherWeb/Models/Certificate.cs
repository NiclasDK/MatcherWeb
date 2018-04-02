using System;
using System.ComponentModel.DataAnnotations;

namespace ITMatcherWeb.Models
{
    public class Certificate
    {
        public string CertificateId { get; set; }
        public DateTime? DateOfCertification { get; set; }
        public string Name { get; set; }
        public string CertificationProvider { get; set;}
        [Required]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int ApplicationUserId { get; set; }

    }
}