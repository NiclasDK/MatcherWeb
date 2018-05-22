namespace ITMatcherWeb.Models
{
    public class Education
    {
        public int EducationId { get; set; }
        public string EducationName { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public string SchoolName{ get; set; }
    }

    public enum EducationLevel
    {
        High_school, University, Elementary, PHD, Cand, AP_graduate
    }
}