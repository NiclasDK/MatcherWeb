using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ITMatcherWeb.DataContexts;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace ITMatcherWeb.Controllers
{
    public class ProfileController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        public ActionResult Profile()
        {
            if (User.IsInRole("Admin1") || User.IsInRole("Admin2") || User.IsInRole("Admin3"))
            {
                ViewBag.IsOfAdminType = true;
            }
            else
            {
                ViewBag.IsOfAdminType = false;
            }

            var UserId = User.Identity.GetUserId();
            var user = db.Users.Where(u => u.Id == UserId).Include(j => j.JobExperiences).ToList();
            ViewBag.CurrentUserId = UserId;

            return View("profilePage", user);
        }
    }
}