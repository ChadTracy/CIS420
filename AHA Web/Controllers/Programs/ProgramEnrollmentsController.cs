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
    public class ProgramEnrollmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProgramEnrollments
        public ActionResult Index()
        {
            var programEnrollment = db.ProgramEnrollment.Include(p => p.Program);
            return View(programEnrollment.ToList());
        }

        // GET: ProgramEnrollments/Details/5
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
        public ActionResult LandingPageView()
        {
            var db = new ApplicationDbContext();
            IEnumerable<SelectListItem> items = db.Events
              .Select(e => new SelectListItem
              {
                  Value = e.EventID.ToString(),
                  Text = e.text
              });
            ViewBag.Events = items;
            IEnumerable<SelectListItem> progs = db.Programs
              .Select(p => new SelectListItem
              {
                  Value = p.Program_ID.ToString(),
                  Text = p.Program_Name
              });
            ViewBag.Programs = progs;
            return View();

        }
        // GET: ProgramEnrollments/Create
        public ActionResult Create()
        {
            ViewBag.Program_ID = new SelectList(db.Programs, "Program_ID", "Program_Name");
            return View();
        }

        // POST: ProgramEnrollments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Enrollment_Number,StudentEmail,Program_ID,EventID,StartTime,EndTime,Attended")] ProgramEnrollment programEnrollment)
        {
            if (ModelState.IsValid)
            {
                db.ProgramEnrollment.Add(programEnrollment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Program_ID = new SelectList(db.Programs, "Program_ID", "Program_Name", programEnrollment.Program_ID);
            return View(programEnrollment);
        }

        // GET: ProgramEnrollments/Edit/5
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
            return View(programEnrollment);
        }

        // POST: ProgramEnrollments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Enrollment_Number,StudentEmail,Program_ID,EventID,StartTime,EndTime,Attended")] ProgramEnrollment programEnrollment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(programEnrollment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Program_ID = new SelectList(db.Programs, "Program_ID", "Program_Name", programEnrollment.Program_ID);
            return View(programEnrollment);
        }

        // GET: ProgramEnrollments/Delete/5
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

        // POST: ProgramEnrollments/Delete/5
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
