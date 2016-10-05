using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AHA_Web.Models;

namespace AHA_Web.Controllers.Volunteers
{
    public class VolunteerHistoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VolunteerHistory
        public ActionResult Index()
        {
            var volunteerHistory = db.VolunteerHistory.Include(v => v.Volunteer);
            return View(volunteerHistory.ToList());
        }

        // GET: VolunteerHistory/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VolunteerHistory volunteerHistory = db.VolunteerHistory.Find(id);
            if (volunteerHistory == null)
            {
                return HttpNotFound();
            }
            return View(volunteerHistory);
        }

        // GET: VolunteerHistory/Create
        public ActionResult Create()
        {
            ViewBag.Volunteer_ID = new SelectList(db.Volunteers, "Volunteer_ID", "First_Name");
            return View();
        }

        // POST: VolunteerHistory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Volunteer_ID,Event_ID,Hours_Worked")] VolunteerHistory volunteerHistory)
        {
            if (ModelState.IsValid)
            {
                db.VolunteerHistory.Add(volunteerHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Volunteer_ID = new SelectList(db.Volunteers, "Volunteer_ID", "First_Name", volunteerHistory.Volunteer_ID);
            return View(volunteerHistory);
        }

        // GET: VolunteerHistory/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VolunteerHistory volunteerHistory = db.VolunteerHistory.Find(id);
            if (volunteerHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.Volunteer_ID = new SelectList(db.Volunteers, "Volunteer_ID", "First_Name", volunteerHistory.Volunteer_ID);
            return View(volunteerHistory);
        }

        // POST: VolunteerHistory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Volunteer_ID,Event_ID,Hours_Worked")] VolunteerHistory volunteerHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(volunteerHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Volunteer_ID = new SelectList(db.Volunteers, "Volunteer_ID", "First_Name", volunteerHistory.Volunteer_ID);
            return View(volunteerHistory);
        }

        // GET: VolunteerHistory/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VolunteerHistory volunteerHistory = db.VolunteerHistory.Find(id);
            if (volunteerHistory == null)
            {
                return HttpNotFound();
            }
            return View(volunteerHistory);
        }

        // POST: VolunteerHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            VolunteerHistory volunteerHistory = db.VolunteerHistory.Find(id);
            db.VolunteerHistory.Remove(volunteerHistory);
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
