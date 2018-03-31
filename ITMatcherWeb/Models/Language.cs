namespace ITMatcherWeb.Models
{
    public class Language
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public LanguageMastery Mastery { get; set; }

        public virtual ApplicationUser User { get; set; }
        public string ApplicationUserId  { get; set; }
    }

    public enum LanguageMastery
    {
        Basic,
        Good,
        Excellent,
        native,
    }
}