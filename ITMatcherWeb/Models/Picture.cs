using System.ComponentModel.DataAnnotations;

namespace ITMatcherWeb.Models
{
    public class Picture
    {
        [Key]
        public string PictureId { get; set; }
        public string PicturePath { get; set; }
    }
}