using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITMatcherWeb.DataContexts;
using ITMatcherWeb.Models;

namespace ITMatcherWeb.Controllers
{
    [Authorize]
    public class EnvironmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Environments
        public ActionResult Index()
        {
            return View(db.Environments.ToList());
        }

        public ActionResult EnvironmentList(int id)
        {
            ViewBag.environmentId = id;

            if (id.ToString() == "")
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var EnvironmentList = db.Environments.Where(e => e.EnvironmentId == id).SelectMany(c => c.JobExperiences).ToList();

            //var EnvironmentList = db.Environments.Where(s => s. == id).ToList();
            return View(EnvironmentList);
        }


        // GET: Environments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Environment environment = db.Environments.Find(id);
            if (environment == null)
            {
                return HttpNotFound();
            }
            return View(environment);
        }

        // GET: Environments/Create
        public ActionResult Create()
        {
            ViewBag.Environments = db.Environments;

            return View();
        }

        public ActionResult AdminCreate()
        {
            return View("AdminCreate");
        }

        // POST: Environments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnvironmentId,EnvironmentName")] Models.Environment environment, int id)
        {
            //environment.JobExperienceId = id;
            environment.JobExperiences.Where(j => j.JobExperienceId == id).First();


            if (ModelState.IsValid)
            {
                db.Environments.Add(environment);
                db.SaveChanges();
                return RedirectToAction("EnvironmentList/" + id);
            }

            return View(environment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminEnvCreation([Bind(Include = "EnvironmentId,EnvironmentName, IsAccepted")] Models.Environment environment)
        {

            if (ModelState.IsValid)
            {
                db.Environments.Add(environment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(environment);
        }


        // GET: Environments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Environment environment = db.Environments.Find(id);
            if (environment == null)
            {
                return HttpNotFound();
            }
            return View(environment);
        }

        // POST: Environments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnvironmentId,EnvironmentName")] Models.Environment environment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(environment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(environment);
        }

        // GET: Environments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Environment environment = db.Environments.Find(id);
            if (environment == null)
            {
                return HttpNotFound();
            }
            return View(environment);
        }

        // POST: Environments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.Environment environment = db.Environments.Find(id);
            db.Environments.Remove(environment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
