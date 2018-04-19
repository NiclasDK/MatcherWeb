using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITMatcherWeb.Models
{
    public class Bulletin
    {
        public int BulletinId { get; set; }
        public DateTime? DateAdded { get; set; }
        public string Text { get; set; }
        public bool Active { get; set; } = false;
        public string Type { get; set; }
        public virtual Picture Picture { get; set; }
        public int PictureId { get; set; }
    }

}