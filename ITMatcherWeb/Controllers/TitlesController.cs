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
    public class TitlesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Titles
        public ActionResult Index()
        {
            return View(db.Titles.ToList());
        }

        public ActionResult TitlesList(int id)
        {
            ViewBag.TitleId = id;

            if (id.ToString() == "")
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var TitleList = db.Titles.Where(t => t.TitleId == id).SelectMany(c => c.JobExperiences).ToList();
            //var TitleList2 = db.Titles.Where(t => t.
            //var TitleList = db.Titles.Where(t => t.JobExperienceId == id).ToList();
            return View(TitleList);
        }

        // GET: Titles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Title title = db.Titles.Find(id);
            if (title == null)
            {
                return HttpNotFound();
            }
            return View(title);
        }

        // GET: Titles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Titles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TitleId,TitleName,IsAccepted")] Title title, int id)
        {
            //title.JobExperienceId = id;
            title.JobExperiences.Where(j => j.JobExperienceId == id).First();


            if (ModelState.IsValid)
            {
                db.Titles.Add(title);
                db.SaveChanges();
                return RedirectToAction("TitlesList/"+id);
            }

            return View(title);
        }

        // GET: Titles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Title title = db.Titles.Find(id);
            if (title == null)
            {
                return HttpNotFound();
            }
            return View(title);
        }

        // POST: Titles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TitleId,TitleName,IsAccepted")] Title title)
        {
            if (ModelState.IsValid)
            {
                db.Entry(title).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(title);
        }

        // GET: Titles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Title title = db.Titles.Find(id);
            if (title == null)
            {
                return HttpNotFound();
            }
            return View(title);
        }

        // POST: Titles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Title title = db.Titles.Find(id);
            db.Titles.Remove(title);
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
