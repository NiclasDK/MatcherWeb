using ITMatcherWeb.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ITMatcherWeb.DataContexts
{
    public class PictureDb : DbContext
    {
        public virtual DbSet<Picture> Pictures { get; set; }

        public PictureDb() : base("DefaultConnection")
        {

        }
    }
}