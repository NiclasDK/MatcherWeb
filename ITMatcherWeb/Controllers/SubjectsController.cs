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
    public class SubjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Subjects
        [Authorize(Roles = "Admin3, Admin2, Admin1")]
        public ActionResult Index()
        {
            return View(db.Subjects.ToList());
        }



        // GET: Subjects/Details/5
        public ActionResult Details(int id)
        {
            if (id.ToString() == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // GET: Subjects/Create
        public ActionResult Create()
        {
            ViewBag.SubjectDropDown = db.Subjects;

            return View();
        }

        public ActionResult AdminCreate()
        {
            return View("AdminCreate");
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubjectId,Name,StartTime,EndTime,PercievedLevelOfSkill")] Subject subject, int id)
        {

            subject.JobExperiences.Where(j => j.JobExperienceId == id).First();

            if (ModelState.IsValid)
            {
                db.Subjects.Add(subject);
                db.SaveChanges();
                return RedirectToAction("SubjectList/"+id);
            }

            return View(subject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminCreate([Bind(Include = "SubjectId,Name,StartTime,EndTime,PercievedLevelOfSkill")] Subject subject)
        {

            if (ModelState.IsValid)
            {
                db.Subjects.Add(subject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subject);
        }

        // GET: Subjects/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubjectId,Name,StartTime,EndTime,PercievedLevelOfSkill")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subject);
        }

        // GET: Subjects/Delete/5
        public ActionResult Delete(int id)
        {
            if (id.Equals(""))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subject subject = db.Subjects.Find(id);
            db.Subjects.Remove(subject);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SubjectList(int id)
        {
            ViewBag.subjectId = id;

            if (id.ToString()=="")
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var subjectList = db.Subjects.Where(s => s.SubjectId== id).SelectMany(c => c.JobExperiences).ToList();

            //var subjectList = db.Subjects.Where(s => s.JobExperienceId == id).ToList();
            return View(subjectList);
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
