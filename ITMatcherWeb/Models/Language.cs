using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITMatcherWeb.Models
{
    public class Language
    {
        [Key]
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public LanguageMastery Mastery { get; set; }
        //public virtual User ApplicationUser { get; set; }
        public virtual ICollection<User> Users{ get; set; }

        public Language()
        {
            this.Users = new HashSet<User>();
        }
    }

    public enum LanguageMastery
    {
        Basic,
        Good,
        Excellent,
        native,
    }


}