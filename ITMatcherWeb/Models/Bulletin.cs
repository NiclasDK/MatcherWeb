using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITMatcherWeb.Models
{
    public class Bulletin
    {
        public string BulletinId { get; set; }
        public Picture Picture { get; set; }
        public DateTime? DateAdded { get; set; }
        public string Text { get; set; }
        public bool Active { get; set; }
    }
}