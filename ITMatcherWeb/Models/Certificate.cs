using System;

namespace ITMatcherWeb.Models
{
    public class Certificate
    {
        public string CertificateId { get; set; }
        public DateTime? DateOfCertification { get; set; }
        public string Name { get; set; }
        public string CertificationProvider { get; set; }
    }
}