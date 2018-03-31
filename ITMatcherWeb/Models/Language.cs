namespace ITMatcherWeb.Models
{
    public class Language
    {
        public string LanguageId { get; set; }
        public string Name { get; set; }
        public LanguageMastery Mastery { get; set; }
    }

    public enum LanguageMastery
    {
        Basic,
        Good,
        Excellent,
        native,
    }


}