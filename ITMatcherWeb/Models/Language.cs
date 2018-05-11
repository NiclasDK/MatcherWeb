using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITMatcherWeb.Models
{
    public class Language
    {
        public string LanguageId { get; set; }
        public string Name { get; set; }
        public LanguageMastery Mastery { get; set; }
        public virtual User ApplicationUser { get; set; }
    }

    public enum LanguageMastery
    {
        Basic,
        Good,
        Excellent,
        native,
    }


}