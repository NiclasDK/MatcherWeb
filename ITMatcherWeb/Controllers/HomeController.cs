using ITMatcherWeb.DataContexts;
using ITMatcherWeb.Models;
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

            /*Project Managers*/
            if ((from u in db.Users
                 from j in u.JobExperiences
                 from t in j.Titles
                 select t.TitleName == "Project manager").Any())
            {

                ViewBag.numberOfProjectMangers = db.Users
                .Where(u => u.JobExperiences.Any(j => j.Titles.Any(t => t.TitleName == "Project manager")))
                .Count();

            }
            else {
                ViewBag.numberOfProjectMangers = 0;
            }

            /*Test-managere*/
            if ((from u in db.Users
                 from j in u.JobExperiences
                 from t in j.Titles
                 select t.TitleName== "Test manager").Any())
            {
                ViewBag.numberOfTestmanagers = db.Users
                .Where(u => u.JobExperiences.Any(j => j.Titles.Any(t => t.TitleName == "Test manager")))
                .Count();
            }
            else
            {
                ViewBag.numberOfTestmanagers = 0;
            }
            /*Systemudviklere*/
            if ((from u in db.Users
                 from j in u.JobExperiences
                 from t in j.Titles
                 select t.TitleName == "System developer").Any())
            {
                ViewBag.numberOfSystemDev = db.Users
                .Where(u => u.JobExperiences.Any(j => j.Titles.Any(t => t.TitleName == "System developer")))
                .Count();
            }
            else
            {
                ViewBag.numberOfSystemDev = 0;
            }
            /*Testere*/
            

            if ((from u in db.Users
                 from j in u.JobExperiences
                 from t in j.Titles
                 select t.TitleName == "Tester").Any())
            {
                ViewBag.numberOfTesters = db.Users
                .Where(u => u.JobExperiences.Any(j => j.Titles.Any(t => t.TitleName == "Tester")))
                .Count();

            }
            else
            {
                ViewBag.numberOfTesters = 0;
            }


            return View();
        }

    }
}