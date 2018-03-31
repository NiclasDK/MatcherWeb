using ITMatcherWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ITMatcherWeb.DataContext
{
    public class CertificateDb : DbContext
    {

        public DbSet<Certificate> Certificates { get; set; }

        public CertificateDb()
            : base("DefaultConnection")
        {
        }
    }