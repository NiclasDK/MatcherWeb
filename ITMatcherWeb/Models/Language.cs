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
        public virtual ICollection<UserLanguages> Users{ get; set; }
    }

    public enum LanguageMastery
    {
        Basic,
        Good,
        Excellent,
        native,
    }


}