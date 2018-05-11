using ITMatcherWeb.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITMatcherWeb.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {

            ViewBag.numberOfProjectMangers = from u in db.Users
                                             from j in u.JobExperiences
                                             from s in j.Subjects
                                             select s.Name == "Project manager";
                                                
            return View();
        }

    }
}