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
using Microsoft.AspNet.Identity;

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

            //db.Subjects.ToList()
            //Returns a view with distinct values. All subjects are grouped by name then first in group is added to list
            return View(db.Subjects.GroupBy(s => s.Name).Select(s=>s.FirstOrDefault()).ToList());
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
            ViewBag.SubjectDropDown = db.Subjects.Where(s=> s.IsAccepted==true);

            return View();
        }

        [Authorize(Roles = "Admin1, Admin2, Admin3")]
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

            //var subjectList = db.Subjects.Where(s => s.JobExperiences.Any(j => j.JobExperienceId == id)).ToList();
            //var jobExpList = db.JobExperiences.Include(j => j.Subjects).Where(j => j.JobExperienceId == id).Single();
            JobExperience jobExp = db.JobExperiences.FirstOrDefault(j => j.JobExperienceId == id);

            jobExp.Subjects.Add(subject);
            //subject.JobExperiences.FirstOrDefault(j => j.JobExperienceId == id);


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
        public ActionResult AdminCreate([Bind(Include = "SubjectId,Name")] Subject subject)
        {
            subject.IsAccepted = true;

            if (ModelState.IsValid)
            {
                db.Subjects.Add(subject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subject);
        }

        // GET: Subjects/Edit/5
        public ActionResult Edit(int id)
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

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubjectId,Name,StartTime,EndTime,PercievedLevelOfSkill, IsAccepted")] Subject subject)
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

            if (User.IsInRole("Admin1") || User.IsInRole("Admin2") || User.IsInRole("Admin3"))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("ProfileJobIndex", "JobExperiences");
            }

        }

        public ActionResult SubjectList(int id)
        {
            ViewBag.subjectId = id;

            if (id.ToString()=="")
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //context.Parent.Where(e => e.ParentId == RequiredParentId).SelectMany(e => e.Child)
            //var jobExpList = db.JobExperiences.Include(j => j.Subjects).Where(j => j.JobExperienceId == id);
            //var subjectList = jobExpList.

            var subjectList = db.Subjects.Where(s => s.JobExperiences.Any(j => j.JobExperienceId == id)).ToList();

            //var subjectList = db.Subjects.Where(s => s.JobExperiences== id).SelectMany(s => s.Subjects).ToList();
            //var subjectList = db.Subjects.Where(t => t.SubjectId == id);
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
