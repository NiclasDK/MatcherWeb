using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITMatcherWeb.Models
{
    public class UserLanguages
    {
        public string UserId{ get; set; }
        public int LanguageId { get; set; }
        public virtual User User { get; set; }
        public virtual Language Language { get; set; }
        public LanguageMastery LanguageMastery { get; set; }
    }
}