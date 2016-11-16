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

namespace AHA_Web.Controllers.Programs
{
    public class ProgramController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        protected ApplicationDbContext ApplicationDbContext { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }
        private ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

        public ProgramController()
        {
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
        }

        // GET: Program
        public ActionResult Index()
        {
            return View(db.Programs.ToList());
        }

        // GET: Program/Details/5
        public ActionResult Details(string id)
        {
            Program program = db.Programs.Find(id);
            if (user.AccountType == "Admin" || user.AccountType == "Staff")
            {
                return View(program);
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

        // GET: Program/Create
        public ActionResult Create()
        {
            if (user.AccountType == "Admin" || user.AccountType == "Staff")
            {
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

        // POST: Program/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Program_ID,Program_Name,Program_Location,Description")] Program program)
        {
            if (ModelState.IsValid)
            {
                db.Programs.Add(program);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(program);
        }

        // GET: Program/Edit/5
        public ActionResult Edit(string id)
        {
            Program program = db.Programs.Find(id);
            if (user.AccountType == "Admin" || user.AccountType == "Staff")
            {
                return View(program);
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

        // POST: Program/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Program_ID,Program_Name,Program_Location,Description")] Program program)
        {
            if (ModelState.IsValid)
            {
                db.Entry(program).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(program);
        }

        // GET: Program/Delete/5
        public ActionResult Delete(string id)
        {
            Program program = db.Programs.Find(id);
            if (user.AccountType == "Admin" || user.AccountType == "Staff")
            {
                return View(program);
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

        // POST: Program/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Program program = db.Programs.Find(id);
            db.Programs.Remove(program);
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
