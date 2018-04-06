using ITMatcherWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ITMatcherWeb.DataContexts
{
    public class BulletinDb : DbContext
    {
        public virtual DbSet<Picture> Pictures { get; set; }

        public BulletinDb() : base("DefaultConnection")
        {

        }

    }
}