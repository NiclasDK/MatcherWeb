namespace ITMatcherWeb.Models
{
    public class Language
    {
        string Id;
        string name;
        LanguageMastery mastery;
    }

    internal enum LanguageMastery
    {
        Basic,
        Good,
        Excellent,
        native,
    }
}