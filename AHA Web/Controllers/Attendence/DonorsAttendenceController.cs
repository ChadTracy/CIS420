using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AHA_Web.Models;

namespace AHA_Web.Controllers.Attendence
{
    public class DonorsAttendenceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DonorsAttendence
        public ActionResult Index()
        {
            var donorAttendence = db.DonorAttendence.Include(d => d.Donor);
            return View(donorAttendence.ToList());
        }

        // GET: DonorsAttendence/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorsAttendence donorsAttendence = db.DonorAttendence.Find(id);
            if (donorsAttendence == null)
            {
                return HttpNotFound();
            }
            return View(donorsAttendence);
        }

        // GET: DonorsAttendence/Create
        public ActionResult Create()
        {
            ViewBag.Donor_ID = new SelectList(db.Donors, "Donor_ID", "First_Name");
            return View();
        }

        // POST: DonorsAttendence/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Donor_ID,Event_ID,Sign_In_Time,Sign_Out_Time")] DonorsAttendence donorsAttendence)
        {
            if (ModelState.IsValid)
            {
                db.DonorAttendence.Add(donorsAttendence);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Donor_ID = new SelectList(db.Donors, "Donor_ID", "First_Name", donorsAttendence.Donor_ID);
            return View(donorsAttendence);
        }

        // GET: DonorsAttendence/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorsAttendence donorsAttendence = db.DonorAttendence.Find(id);
            if (donorsAttendence == null)
            {
                return HttpNotFound();
            }
            ViewBag.Donor_ID = new SelectList(db.Donors, "Donor_ID", "First_Name", donorsAttendence.Donor_ID);
            return View(donorsAttendence);
        }

        // POST: DonorsAttendence/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Donor_ID,Event_ID,Sign_In_Time,Sign_Out_Time")] DonorsAttendence donorsAttendence)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donorsAttendence).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Donor_ID = new SelectList(db.Donors, "Donor_ID", "First_Name", donorsAttendence.Donor_ID);
            return View(donorsAttendence);
        }

        // GET: DonorsAttendence/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorsAttendence donorsAttendence = db.DonorAttendence.Find(id);
            if (donorsAttendence == null)
            {
                return HttpNotFound();
            }
            return View(donorsAttendence);
        }

        // POST: DonorsAttendence/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DonorsAttendence donorsAttendence = db.DonorAttendence.Find(id);
            db.DonorAttendence.Remove(donorsAttendence);
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
