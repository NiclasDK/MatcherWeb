﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
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
    public class UsersController : Controller
    {
        
        private ApplicationDbContext db = new ApplicationDbContext();

        //Gets a list of all users in system
        [Authorize(Roles = "Admin1, Admin2, Admin3")]
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.SubjectDropDown = db.Subjects.Where(s => s.IsAccepted == true);

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.LastNameSortParm = sortOrder == "LastName" ? "lastname_desc" : "LastName";
            ViewBag.EmailSortParm = sortOrder == "Email" ? "email_desc" : "Email";
            ViewBag.SalSortParm = sortOrder == "Salary" ? "sal_desc" : "Salary";

            var users = from u in db.Users
                           select u;

            //Finds users with subject defined by searchString
            if (!String.IsNullOrEmpty(searchString))
            {
                users = db.Users.Where(u => u.JobExperiences.Any(h =>  h.Subjects.Any(d => d.Name == searchString)));
            }

            //Orders data based on click
            switch (sortOrder)
            {
                case "name_desc":
                    users = users.OrderByDescending(s => s.FirstName);
                    break;
                case "lastname_desc":
                    users = users.OrderByDescending(s => s.LastName);
                    break;
                case "LastName":
                    users = users.OrderBy(s => s.LastName);
                    break;
                case "expec_sal":
                    users = users.OrderByDescending(s => s.ExpectedHourlySalary);
                    break;
                case "Salary":
                    users = users.OrderBy(s => s.ExpectedHourlySalary);
                    break;
                case "email_desc":
                    users = users.OrderByDescending(s => s.Email);
                    break;
                case "Email":
                    users = users.OrderBy(s => s.Email);
                    break;
                default:
                    users = users.OrderBy(s => s.FirstName);
                    break;
            }

            return View(users);
        }

        // HTTPGET. Gets details on user with id=?
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }


        [Authorize(Roles = "Admin3, Admin2")]
        public void ExtractToCsv(string id)
        {
            //Code run in model-class
            User user = new User();
            user.ExtracttoCsv(id);

        }

        // GET: Users/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Available,ActivelySeeking,ExpectedHourlySalary,Gender,DateOfBirth,FirstName,LastName,Email,PhoneNumber")] User user, string id)
        {

            //Explicitly defined variables to be set. ASPNETUSER contain more than the fields below,
            // without explicit variables, the others would be set as well.
            if (ModelState.IsValid)
            {
                var existingUser = db.Users.SingleOrDefault(u => u.Id == id);
                existingUser.Available = user.Available;
                existingUser.ActivelySeeking = user.ActivelySeeking;
                existingUser.ExpectedHourlySalary = user.ExpectedHourlySalary;
                existingUser.Gender = user.Gender;
                existingUser.DateOfBirth = user.DateOfBirth;
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Email = user.Email;
                existingUser.PhoneNumber = user.PhoneNumber;


                // etc.
                db.SaveChanges();

                //db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                //db.SaveChanges();
                if (User.IsInRole("Admin1") || User.IsInRole("Admin2") || User.IsInRole("Admin3"))
                {
                    return RedirectToAction("Index");
                }
                else {
                    return RedirectToAction("Profile", "Profile");
                }
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }


            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {

            //Deletes from bottom to top. Other way would create error.
            User UserToDelete = db.Users.Find(id);
            if (UserToDelete.JobExperiences.Any()) { 
            foreach (JobExperience j in UserToDelete.JobExperiences.ToList()) {
                    if (j.Environments.Any()) { 
                        foreach (Models.Environment e in j.Environments.ToList()) {
                            db.Environments.Remove(e);
                        }
                    }
                    db.JobExperiences.Remove(j);
                }
            }
            db.Users.Remove(UserToDelete);

            db.SaveChanges();

            var loggedInUserId = User.Identity.GetUserId();

            if (loggedInUserId == id)
            {
                return RedirectToAction("LogOffGet", "Account");
            }
            else {
                return RedirectToAction("Index");
            }


            //Logging out after deletion. 
            //Could add a check if the deleted users id is the same as the deletors, if not, logout is not necessary
            //return RedirectToAction("Index");
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
