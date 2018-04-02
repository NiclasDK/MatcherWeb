using ITMatcherWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ITMatcherWeb.DataContexts
{
    public class LanguageDb : DbContext
    {
        public virtual DbSet<Language> Languages { get; set; }


        public LanguageDb() : base("DefaultConnection")
        {

        }
    }
}