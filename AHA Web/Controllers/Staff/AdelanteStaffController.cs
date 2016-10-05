using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AHA_Web.Models;

namespace AHA_Web.Controllers.Staff
{
    public class AdelanteStaffController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdelanteStaff
        public ActionResult Index()
        {
            return View(db.Staff.ToList());
        }

        // GET: AdelanteStaff/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdelanteStaff adelanteStaff = db.Staff.Find(id);
            if (adelanteStaff == null)
            {
                return HttpNotFound();
            }
            return View(adelanteStaff);
        }

        // GET: AdelanteStaff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdelanteStaff/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Staff_ID,First_Name,Middle_Initial,Last_Name,Address,City,State,Zip_Code,Email,Phone,Alt_Phone,Hire_Date")] AdelanteStaff adelanteStaff)
        {
            if (ModelState.IsValid)
            {
                db.Staff.Add(adelanteStaff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adelanteStaff);
        }

        // GET: AdelanteStaff/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdelanteStaff adelanteStaff = db.Staff.Find(id);
            if (adelanteStaff == null)
            {
                return HttpNotFound();
            }
            return View(adelanteStaff);
        }

        // POST: AdelanteStaff/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Staff_ID,First_Name,Middle_Initial,Last_Name,Address,City,State,Zip_Code,Email,Phone,Alt_Phone,Hire_Date")] AdelanteStaff adelanteStaff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adelanteStaff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adelanteStaff);
        }

        // GET: AdelanteStaff/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdelanteStaff adelanteStaff = db.Staff.Find(id);
            if (adelanteStaff == null)
            {
                return HttpNotFound();
            }
            return View(adelanteStaff);
        }

        // POST: AdelanteStaff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AdelanteStaff adelanteStaff = db.Staff.Find(id);
            db.Staff.Remove(adelanteStaff);
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
