using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AHA_Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace AHA_Web.Controllers.Students
{
    public class StudentFamilyController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        protected ApplicationDbContext ApplicationDbContext { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }
        private ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

        public StudentFamilyController()
        {
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
        }

        // GET: StudentFamily
        public ActionResult Index()
        {
            if (user.AccountType == "Admin" || user.AccountType == "AdelanteStaff")
            {
                var studentFamily = db.StudentFamily.Include(s => s.Parent).Include(s => s.Student);
                return View(studentFamily.ToList());
            }
            if (user == null)
            {
                return HttpNotFound();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Sorry, you don't have the proper authorization to access this");
            }

        }

        // GET: StudentFamily/Details/5
        public ActionResult Details(string id)
        {
            StudentFamily studentFamily = db.StudentFamily.Find(id);
            if (user.AccountType == "Admin" || user.AccountType == "AdelanteStaff")
            {
                return View(studentFamily);
            }
            if (user == null || id == null || studentFamily == null)
            {
                return HttpNotFound();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Sorry, you don't have the proper authorization to access this");
            }
           
        }

        // GET: StudentFamily/Create
        public ActionResult Create()
        {
            if (user.AccountType == "Admin" || user.AccountType == "AdelanteStaff")
            {
                ViewBag.Parent_ID = new SelectList(db.Parents, "Parent_ID", "First_Name");
                ViewBag.Student_ID = new SelectList(db.Students, "Student_ID", "First_Name");
                return View();
            }
            if (user == null)
            {
                return HttpNotFound();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Sorry, you don't have the proper authorization to access this");
            }

        }

        // POST: StudentFamily/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Student_ID,Parent_ID,Type")] StudentFamily studentFamily)
        {
            if (ModelState.IsValid)
            {
                db.StudentFamily.Add(studentFamily);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Parent_ID = new SelectList(db.Parents, "Parent_ID", "First_Name", studentFamily.Parent_ID);
            ViewBag.Student_ID = new SelectList(db.Students, "Student_ID", "First_Name", studentFamily.Student_ID);
            return View(studentFamily);
        }

        // GET: StudentFamily/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentFamily studentFamily = db.StudentFamily.Find(id);
            if (studentFamily == null)
            {
                return HttpNotFound();
            }
            ViewBag.Parent_ID = new SelectList(db.Parents, "Parent_ID", "First_Name", studentFamily.Parent_ID);
            ViewBag.Student_ID = new SelectList(db.Students, "Student_ID", "First_Name", studentFamily.Student_ID);
            return View(studentFamily);
        }

        // POST: StudentFamily/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Student_ID,Parent_ID,Type")] StudentFamily studentFamily)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentFamily).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Parent_ID = new SelectList(db.Parents, "Parent_ID", "First_Name", studentFamily.Parent_ID);
            ViewBag.Student_ID = new SelectList(db.Students, "Student_ID", "First_Name", studentFamily.Student_ID);
            return View(studentFamily);
        }

        // GET: StudentFamily/Delete/5
        public ActionResult Delete(string id)
        {
            StudentFamily studentFamily = db.StudentFamily.Find(id);
            if (user.AccountType == "Admin" || user.AccountType == "AdelanteStaff")
            {
                return View(studentFamily);
            }
            if (user == null || id == null || studentFamily == null)
            {
                return HttpNotFound();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Sorry, you don't have the proper authorization to access this");
            }
        }

        // POST: StudentFamily/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            StudentFamily studentFamily = db.StudentFamily.Find(id);
            db.StudentFamily.Remove(studentFamily);
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
