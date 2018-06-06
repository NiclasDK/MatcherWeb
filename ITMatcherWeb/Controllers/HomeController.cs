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
            /*
            if ((from b in db.Bulletins select b.Type == BulletinType.ABOUT).Any()) {
                ViewBag.aboutText = db.Bulletins
                    .Where(b => b.Type == BulletinType.ABOUT);
            }*/


            /*Project Managers*/
            if ((from u in db.Users
                 from j in u.JobExperiences
                 from s in j.Subjects
                 select s.Name == "Project manager").Any())
            {

                ViewBag.numberOfProjectMangers = db.Users
                .Where(u => u.JobExperiences.Any(j => j.Subjects.Any(s => s.Name == "Project manager")))
                .Count();
            }
            else {
                ViewBag.numberOfProjectMangers = 0;
            }

            /*Test-managere*/
            if ((from u in db.Users
                 from j in u.JobExperiences
                 from s in j.Subjects
                 select s.Name == "Test manager").Any())
            {
                ViewBag.numberOfTestmanagers = db.Users
                .Where(u => u.JobExperiences.Any(j => j.Subjects.Any(s => s.Name == "Test manager")))
                .Count();
            }
            else
            {
                ViewBag.numberOfTestmanagers = 0;
            }
            /*Systemudviklere*/
            if ((from u in db.Users
                 from j in u.JobExperiences
                 from s in j.Subjects
                 select s.Name == "System developer").Any())
            {
                ViewBag.numberOfSystemDev = db.Users
                .Where(u => u.JobExperiences.Any(j => j.Subjects.Any(s => s.Name == "System developer")))
                .Count();
            }
            else
            {
                ViewBag.numberOfSystemDev = 0;
            }
            /*Testere*/
            

            if ((from u in db.Users
                 from j in u.JobExperiences
                 from s in j.Subjects
                 select s.Name == "Tester").Any())
            {
                ViewBag.numberOfTesters = db.Users
                .Where(u => u.JobExperiences.Any(j => j.Subjects.Any(s => s.Name == "Tester")))
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