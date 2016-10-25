using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AHA_Web.Models;

namespace AHA_Web.Controllers.Attendances
{
    public class AttendanceTakingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AttendanceTaking
        public ActionResult Index()
        {
            return View(db.Attendance.ToList());
        }

        // GET: AttendanceTaking/Details/5

        public ActionResult TakeAttendance()
        {
            ViewBag.Events = new SelectList(db.Events, "text");
            ViewBag.Programs = new SelectList(db.Programs, "Program_Name");
            return View();
                }
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendance.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // GET: AttendanceTaking/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AttendanceTaking/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Email,SignIn,EventID,Program_ID,SignOut")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.Attendance.Add(attendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(attendance);
        }

        // GET: AttendanceTaking/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendance.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // POST: AttendanceTaking/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Email,SignIn,EventID,Program_ID,SignOut")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attendance);
        }

        // GET: AttendanceTaking/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendance.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // POST: AttendanceTaking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Attendance attendance = db.Attendance.Find(id);
            db.Attendance.Remove(attendance);
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
