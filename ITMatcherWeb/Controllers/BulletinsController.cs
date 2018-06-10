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
    [Authorize(Roles = "Admin1, Admin2, Admin3")]
    public class BulletinsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Bulletins
        public ActionResult Index()
        {
            var bulletins = db.Bulletins.Include(b => b.Picture);
            return View(bulletins.ToList());
        }

        // GET: Bulletins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bulletin bulletin = db.Bulletins.Find(id);
            if (bulletin == null)
            {
                return HttpNotFound();
            }
            return View(bulletin);
        }

        // GET: Bulletins/Create
        public ActionResult Create()
        {
            ViewBag.BulletinId = new SelectList(db.Pictures, "PictureId", "PicturePath");
            return View();
        }

        // POST: Bulletins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BulletinId,DateAdded,Headline,Text,Active,Type,PictureId")] Bulletin bulletin)
        {
            if (ModelState.IsValid)
            {
                db.Bulletins.Add(bulletin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BulletinId = new SelectList(db.Pictures, "PictureId", "PicturePath", bulletin.BulletinId);
            return View(bulletin);
        }

        // GET: Bulletins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bulletin bulletin = db.Bulletins.Find(id);
            if (bulletin == null)
            {
                return HttpNotFound();
            }
            ViewBag.BulletinId = new SelectList(db.Pictures, "PictureId", "PicturePath", bulletin.BulletinId);
            return View(bulletin);
        }

        // POST: Bulletins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BulletinId,DateAdded,Headline,Text,Active,Type,PictureId")] Bulletin bulletin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bulletin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BulletinId = new SelectList(db.Pictures, "PictureId", "PicturePath", bulletin.BulletinId);
            return View(bulletin);
        }

        // GET: Bulletins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bulletin bulletin = db.Bulletins.Find(id);
            if (bulletin == null)
            {
                return HttpNotFound();
            }
            return View(bulletin);
        }

        // POST: Bulletins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bulletin bulletin = db.Bulletins.Find(id);
            db.Bulletins.Remove(bulletin);
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
