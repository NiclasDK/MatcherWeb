﻿using ITMatcherWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ITMatcherWeb.DataContext
{
    public class BulletinDb : DbContext
    {

        public DbSet<Bulletin> Bulletins { get; set; }

        public BulletinDb()
            : base("DefaultConnection")
        {
        }

    }
}