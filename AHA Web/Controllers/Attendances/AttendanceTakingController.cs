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

namespace AHA_Web.Controllers.Attendances
{
    public class AttendanceTakingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        protected ApplicationDbContext ApplicationDbContext { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }
        private ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

        public AttendanceTakingController()
        {
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
        }


        // GET: AttendanceTaking
        public ActionResult Index()
        {
            if (user.AccountType == "Admin" || user.AccountType == "AdelanteStaff")
            {
                return View(db.Attendance.ToList());
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Sorry, you don't have the proper authorization to access this");
            }
            
        }

        // GET: AttendanceTaking/Details/5

        public ActionResult TakeAttendance()
        {
            if (user.AccountType == "Admin" || user.AccountType == "AdelanteStaff")
            {
                ViewBag.Events = new SelectList(db.Events, "text");
                ViewBag.Programs = new SelectList(db.Programs, "Program_Name");
                return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Sorry, you don't have the proper authorization to access this");
            }

        }

        public ActionResult Details(string id)
        {
            Attendance attendance = db.Attendance.Find(id);
            if (user.AccountType == "Admin" || user.AccountType == "AdelanteStaff")
            {
                return View(attendance);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Sorry, you don't have the proper authorization to access this");
            }
            
        }

        // GET: AttendanceTaking/Create
        public ActionResult Create()
        {
            if (user.AccountType == "Admin" || user.AccountType == "AdelanteStaff")
            {
                return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Sorry, you don't have the proper authorization to access this");
            }
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
            Attendance attendance = db.Attendance.Find(id);
            if (user.AccountType == "Admin" || user.AccountType == "AdelanteStaff")
            {
                return View(attendance);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Sorry, you don't have the proper authorization to access this");
            }
        }

        // POST: AttendanceTaking/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Email,SignIn,EventID,Program_ID,SignOut")] Attendance attendance)
        {
            if (user.AccountType == "Admin" || user.AccountType == "AdelanteStaff")
            {
                if (ModelState.IsValid)
                {
                    db.Entry(attendance).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Sorry, you don't have the proper authorization to access this");
            }
            return View(attendance);
        }

        // GET: AttendanceTaking/Delete/5
        public ActionResult Delete(string id)
        {
            Attendance attendance = db.Attendance.Find(id);
            if (user.AccountType == "Admin" || user.AccountType == "AdelanteStaff")
            {
                return View(attendance);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Sorry, you don't have the proper authorization to access this");
            }
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
