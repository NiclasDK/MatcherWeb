using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ITMatcherWeb.DataContext
{
    public class BulletinDb : DbContext
    {

        public BulletinDb()
            : base("DefaultConnection")
        {
        }

    }
}