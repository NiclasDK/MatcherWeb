using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ITMatcherWeb.Controllers
{
    public class ProfileController : Controller
    {
        //Get ID of current user -> Get role of current user -> Pass to view.
        // GET: Profile
        //[Authorize]
        public ActionResult Profile()
        {
            return View("profilePage");
        }
    }
}