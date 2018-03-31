using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITMatcherWeb.Models
{
    public class Bulletin
    {
        public string BulletinId { get; set; }
        public Picture picture { get; set; }
        public DateTime? dateAdded { get; set; }
        public string text { get; set; }
        public bool active { get; set; }
    }
}