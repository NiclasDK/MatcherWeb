using System.ComponentModel.DataAnnotations;

namespace ITMatcherWeb.Models
{
    public class Language
    {
        [Key]
        public string LanguageId { get; set; }
        public string Name { get; set; }
        public LanguageMastery Mastery { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }

    public enum LanguageMastery
    {
        Basic,
        Good,
        Excellent,
        native,
    }


}