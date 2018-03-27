using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITMatcherWeb.Models
{
    public class Bulletin
    {  
        string BulletinId;
        Picture picture;
        DateTime dateAdded;
        string text;
        bool active = false;
    }
}