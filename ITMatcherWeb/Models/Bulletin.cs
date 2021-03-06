﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITMatcherWeb.Models
{
    public class Bulletin
    {
        [Key]
        public int BulletinId { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateAdded { get; set; }
        public string Headline { get; set; }
        public string Text { get; set; }
        public bool Active { get; set; } = false;
        public BulletinType Type { get; set; }
        public virtual Picture Picture { get; set; }
        public int PictureId { get; set; }
    }

    public enum BulletinType {
           ABOUT, CONTACT, NEWS, ARRANGEMENT
    }

}