using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITMatcherWeb.Models
{
    public class Picture
    {
        public int PictureId { get; set; }
        public string PicturePath { get; set; }
        public virtual Bulletin Bulletin { get; set; }
        public int BulletinId { get; set; }
    }
}