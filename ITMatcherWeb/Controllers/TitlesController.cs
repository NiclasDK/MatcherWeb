﻿using System;
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
    public class TitlesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Titles

        public ActionResult Index()
        {
            return View(db.Titles.GroupBy(t => t.TitleName).Select(t => t.FirstOrDefault()).ToList());
        }

        public ActionResult TitlesList(int id)
        {
            ViewBag.TitleId = id;

            if (id.ToString() == "")
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var TitleList = db.Titles.Where(t => t.JobExperiences.Any(j => j.JobExperienceId == id)).ToList();

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
        public ActionResult Create(int id)
        {
            ViewBag.jobExpId = id;
            ViewBag.TitleDropDown = db.Titles.GroupBy(t => t.TitleName).Select(t => t.FirstOrDefault()).Where(t => t.IsAccepted == true).ToList();

            return View();
        }

        [Authorize(Roles = "Admin1, Admin2, Admin3")]
        public ActionResult AdminCreate()
        {
            return View("AdminCreate");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminCreate([Bind(Include = "TitleId,TitleName")] Title title)
        {
            title.IsAccepted = true;

            if (ModelState.IsValid)
            {
                db.Titles.Add(title);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(title);
        }

        // POST: Titles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TitleId,TitleName,IsAccepted")] Title title, int id)
        {

            if (ModelState.IsValid)
            {
                JobExperience jobExp = db.JobExperiences.FirstOrDefault(j => j.JobExperienceId == id);
                jobExp.Titles.Add(title);
                db.SaveChanges();
                return RedirectToAction("TitlesList/"+id);
            }

            return View(title);
        }*/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTitleToJobexp(Title title, int id)
        {
            Title TitleUsed = db.Titles.FirstOrDefault(t => t.TitleName == title.TitleName);

            if (ModelState.IsValid)
            {
                JobExperience jobExp = db.JobExperiences.FirstOrDefault(j => j.JobExperienceId == id);
                jobExp.Titles.Add(TitleUsed);
                db.SaveChanges();
                return RedirectToAction("TitlesList/" + id);
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

            if (User.IsInRole("Admin3"))
            {
                List<Title> list = db.Titles.Where(t => t.TitleName == title.TitleName).ToList();
                foreach (Title t in list)
                {
                    db.Titles.Remove(t);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            else { 
                db.Titles.Remove(title);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
