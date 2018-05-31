using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ITMatcherWeb.DataContexts;
using Microsoft.AspNet.Identity;

namespace ITMatcherWeb.Controllers
{
    public class ProfileController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        public ActionResult Profile()
        {
            var UserId = User.Identity.GetUserId();
            var jobExpList = db.JobExperiences.Where(j => j.ApplicationUser.Id == UserId).ToList();

            if (jobExpList != null) { 
                ViewBag.JobExpList = jobExpList;
            }

            return View("profilePage");
        }
    }
}