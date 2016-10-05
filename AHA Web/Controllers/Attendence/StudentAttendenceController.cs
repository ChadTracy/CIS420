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
    public class StudentAttendenceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StudentAttendence
        public ActionResult Index()
        {
            var studentAttendence = db.StudentAttendence.Include(s => s.Student);
            return View(studentAttendence.ToList());
        }

        // GET: StudentAttendence/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAttendence studentAttendence = db.StudentAttendence.Find(id);
            if (studentAttendence == null)
            {
                return HttpNotFound();
            }
            return View(studentAttendence);
        }

        // GET: StudentAttendence/Create
        public ActionResult Create()
        {
            ViewBag.Student_ID = new SelectList(db.Students, "Student_ID", "First_Name");
            return View();
        }

        // POST: StudentAttendence/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Student_ID,Event_ID,Sign_in_Time,Sign_Out_Time")] StudentAttendence studentAttendence)
        {
            if (ModelState.IsValid)
            {
                db.StudentAttendence.Add(studentAttendence);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Student_ID = new SelectList(db.Students, "Student_ID", "First_Name", studentAttendence.Student_ID);
            return View(studentAttendence);
        }

        // GET: StudentAttendence/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAttendence studentAttendence = db.StudentAttendence.Find(id);
            if (studentAttendence == null)
            {
                return HttpNotFound();
            }
            ViewBag.Student_ID = new SelectList(db.Students, "Student_ID", "First_Name", studentAttendence.Student_ID);
            return View(studentAttendence);
        }

        // POST: StudentAttendence/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Student_ID,Event_ID,Sign_in_Time,Sign_Out_Time")] StudentAttendence studentAttendence)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentAttendence).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Student_ID = new SelectList(db.Students, "Student_ID", "First_Name", studentAttendence.Student_ID);
            return View(studentAttendence);
        }

        // GET: StudentAttendence/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAttendence studentAttendence = db.StudentAttendence.Find(id);
            if (studentAttendence == null)
            {
                return HttpNotFound();
            }
            return View(studentAttendence);
        }

        // POST: StudentAttendence/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            StudentAttendence studentAttendence = db.StudentAttendence.Find(id);
            db.StudentAttendence.Remove(studentAttendence);
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
