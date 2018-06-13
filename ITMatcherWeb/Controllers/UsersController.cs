using System;
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

        // GET: Users
        [Authorize(Roles = "Admin3")]
        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.LastNameSortParm = sortOrder == "LastName" ? "lastname_desc" : "LastName";
            ViewBag.EmailSortParm = sortOrder == "Email" ? "email_desc" : "Email";
            ViewBag.SalSortParm = sortOrder == "Salary" ? "sal_desc" : "Salary";

            var users = from u in db.Users
                           select u;

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

        // GET: Users/Details/5
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
            StringWriter sw = new StringWriter();

            sw.WriteLine("\"First name\",\"Last name\"");

            Response.ClearContent();
            Response.AddHeader("content-disposition","attachment;filename=exportedConsultents.csv");
            Response.ContentType = "text/csv";

            var user = db.Users.Find(id);

            sw.WriteLine(string.Format("\"{0}\",\"{1}\"",
                user.FirstName,
                user.LastName
                ));

            Response.Write(sw.ToString());
            Response.End();
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
        public ActionResult Edit([Bind(Include = "Available,ActivelySeeking,ExpectedHourlySalary,Gender,DateOfBirth,FirstName,LastName,Email,PhoneNumber, Zipcode, City")] User user)
        {
            if (ModelState.IsValid)
            {
                string id = user.Id;
                var existingUser = db.Users.Single(u => u.Id == id);
                existingUser.Available = user.Available;
                existingUser.ActivelySeeking = user.ActivelySeeking;
                existingUser.ExpectedHourlySalary = user.ExpectedHourlySalary;
                existingUser.Gender = user.Gender;
                existingUser.DateOfBirth = user.DateOfBirth;
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Email = user.Email;
                existingUser.PhoneNumber = user.PhoneNumber;
                existingUser.Zipcode = user.Zipcode;
                existingUser.City = user.City;

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
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("LogOffGet", "Account");
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
