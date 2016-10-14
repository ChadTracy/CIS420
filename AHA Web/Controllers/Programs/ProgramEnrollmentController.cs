using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AHA_Web.Models;

namespace AHA_Web.Controllers.Programs
{
    public class ProgramEnrollmentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProgramEnrollment
        public ActionResult Index()
        {
            var programEnrollment = db.ProgramEnrollment.Include(p => p.Program).Include(p => p.Student);
            return View(programEnrollment.ToList());
        }

        // GET: ProgramEnrollment/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramEnrollment programEnrollment = db.ProgramEnrollment.Find(id);
            if (programEnrollment == null)
            {
                return HttpNotFound();
            }
            return View(programEnrollment);
        }

        // GET: ProgramEnrollment/Create
        public ActionResult Create()
        {
            ViewBag.Program_ID = new SelectList(db.Programs, "Program_ID", "Program_Name");
            ViewBag.Student_ID = new SelectList(db.Students, "Student_ID", "First_Name");
            return View();
        }

        // POST: ProgramEnrollment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Program_ID,Student_ID,Enrollment_Period")] ProgramEnrollment programEnrollment)
        {
            if (ModelState.IsValid)
            {
                db.ProgramEnrollment.Add(programEnrollment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Program_ID = new SelectList(db.Programs, "Program_ID", "Program_Name", programEnrollment.Program_ID);
            ViewBag.Student_ID = new SelectList(db.Students, "Student_ID", "First_Name", programEnrollment.Student_ID);
            return View(programEnrollment);
        }

        // GET: ProgramEnrollment/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramEnrollment programEnrollment = db.ProgramEnrollment.Find(id);
            if (programEnrollment == null)
            {
                return HttpNotFound();
            }
            ViewBag.Program_ID = new SelectList(db.Programs, "Program_ID", "Program_Name", programEnrollment.Program_ID);
            ViewBag.Student_ID = new SelectList(db.Students, "Student_ID", "First_Name", programEnrollment.Student_ID);
            return View(programEnrollment);
        }

        // POST: ProgramEnrollment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Program_ID,Student_ID,Enrollment_Period")] ProgramEnrollment programEnrollment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(programEnrollment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Program_ID = new SelectList(db.Programs, "Program_ID", "Program_Name", programEnrollment.Program_ID);
            ViewBag.Student_ID = new SelectList(db.Students, "Student_ID", "First_Name", programEnrollment.Student_ID);
            return View(programEnrollment);
        }

        // GET: ProgramEnrollment/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramEnrollment programEnrollment = db.ProgramEnrollment.Find(id);
            if (programEnrollment == null)
            {
                return HttpNotFound();
            }
            return View(programEnrollment);
        }

        // POST: ProgramEnrollment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ProgramEnrollment programEnrollment = db.ProgramEnrollment.Find(id);
            db.ProgramEnrollment.Remove(programEnrollment);
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
