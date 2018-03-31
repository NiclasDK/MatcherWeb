using ITMatcherWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ITMatcherWeb.DataContext
{
    public class PictureDb : DbContext
    {

        public DbSet<Picture> Pictures { get; set; }

        public PictureDb()
            : base("DefaultConnection")
        {
        }
    }
}