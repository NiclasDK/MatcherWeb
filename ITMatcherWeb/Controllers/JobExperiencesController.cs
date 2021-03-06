﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
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
    public class JobExperiencesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //shows a list of all jobexperiences of a user.
        public ActionResult ProfileJobIndex() {
            var UserId = User.Identity.GetUserId();
            var jobExpList = db.JobExperiences.Where(j => j.ApplicationUser.Id == UserId).ToList();
            return View(jobExpList);
        }

        //
        public ActionResult Index()
        {
            if (User.IsInRole("Admin1") || User.IsInRole("Admin2") || User.IsInRole("Admin3"))
            {
                return View(db.JobExperiences.ToList());
            }
            else
            {
                return RedirectToAction("Profile", "Profile");
            }

            
        }

        // GET: JobExperiences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobExperience jobExperience = db.JobExperiences.Find(id);
            if (jobExperience == null)
            {
                return HttpNotFound();
            }
            return View(jobExperience);
        }

        // GET: JobExperiences/Create
        public ActionResult Create()
        {
            return View();
        }



        // POST: JobExperiences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JobExperienceId,Employer,DateOfEmployment,DateOfExit")] JobExperience jobExperience)
        {
            var UserId = User.Identity.GetUserId();
            jobExperience.ApplicationUser = db.Users.Where(x => x.Id == UserId).First();

            if (ModelState.IsValid)
            {
                    db.JobExperiences.Add(jobExperience);
                    db.SaveChanges();
                    return RedirectToAction("ProfileJobIndex");
            }

            return View(jobExperience);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin3, Admin2")]
        //Adds jobexperience to other user from admin user.
        public ActionResult AddJobFromAdmin([Bind(Include = "JobExperienceId,Employer,DateOfEmployment,DateOfExit")] JobExperience jobExperience, string id) {

            jobExperience.ApplicationUser = db.Users.Where(x => x.Id == id).First();

            if (ModelState.IsValid)
            {
                db.JobExperiences.Add(jobExperience);
                db.SaveChanges();
                return RedirectToAction("ProfileJobIndex");
            }

            return View(jobExperience);
        }

        // GET: JobExperiences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobExperience jobExperience = db.JobExperiences.Find(id);
            if (jobExperience == null)
            {
                return HttpNotFound();
            }
            return View(jobExperience);
        }

        // POST: JobExperiences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobExperienceId,Employer,DateOfEmployment,DateOfExit")] JobExperience jobExperience)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobExperience).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobExperience);
        }

        // GET: JobExperiences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobExperience jobExperience = db.JobExperiences.Find(id);
            if (jobExperience == null)
            {
                return HttpNotFound();
            }
            return View(jobExperience);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //Deletes a jobexperience based on id
        public ActionResult DeleteConfirmed(int id)
        {
            JobExperience jobExperience = db.JobExperiences.Find(id);
            db.JobExperiences.Remove(jobExperience);
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
