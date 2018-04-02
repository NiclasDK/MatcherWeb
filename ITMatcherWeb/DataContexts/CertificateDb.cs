using ITMatcherWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ITMatcherWeb.DataContexts
{
    public class CertificateDb : DbContext
    {
        public virtual DbSet<Certificate> Bulletins { get; set; }

        public CertificateDb() : base("DefaultConnection")
        {

        }
    }
}