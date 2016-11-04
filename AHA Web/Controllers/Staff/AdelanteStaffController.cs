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

namespace AHA_Web.Controllers.Staff
{
    public class AdelanteStaffController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        protected ApplicationDbContext ApplicationDbContext { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }
        private ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

        public AdelanteStaffController()
        {
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
        }

        // GET: AdelanteStaff
        public ActionResult Index()
        {
            if (user.AccountType == "Admin" || user.AccountType == "AdelanteStaff")
            {
                return View(db.Staff.ToList());
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

        // GET: AdelanteStaff/Details/5
        public ActionResult Details(string id)
        {
            AdelanteStaff adelanteStaff = db.Staff.Find(id);
            if (user.AccountType == "Admin" || user.AccountType == "AdelanteStaff")
            {
                return View(adelanteStaff);
            }
            if (user == null || adelanteStaff == null)
            {
                return HttpNotFound();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Sorry, you don't have the proper authorization to access this");
            }

            
        }

        // GET: AdelanteStaff/Create
        public ActionResult Create()
        {
            if (user.AccountType == "Admin" || user.AccountType == "AdelanteStaff")
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
            AdelanteStaff adelanteStaff = db.Staff.Find(id);
            if (user.AccountType == "Admin" || user.AccountType == "AdelanteStaff")
            {
                return View(adelanteStaff);
            }
            if (user == null || id == null || adelanteStaff == null)
            {
                return HttpNotFound();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Sorry, you don't have the proper authorization to access this");
            }
            
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
            AdelanteStaff adelanteStaff = db.Staff.Find(id);
            if (user.AccountType == "Admin" || user.AccountType == "AdelanteStaff")
            {
                return View(adelanteStaff);
            }
            if (user == null || id == null || adelanteStaff == null)
            {
                return HttpNotFound();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Sorry, you don't have the proper authorization to access this");
            }
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
