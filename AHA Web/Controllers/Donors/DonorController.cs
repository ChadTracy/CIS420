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

namespace AHA_Web.Controllers.Donors
{
    public class DonorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        protected ApplicationDbContext ApplicationDbContext { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }
        private ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

        public DonorController()
        {
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
        }

        // GET: Donor
        public ActionResult Index()
        {
            if (user.AccountType == "Admin" || user.AccountType == "AdelanteStaff" || user.AccountType == "Grantor")
            {
                return View(db.Donors.ToList());
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Sorry, you don't have the proper authorization to view this page");
            }
            
        }

        // GET: Donor/Details/5
        public ActionResult Details(string id)
        {
            Donor donor = db.Donors.Find(id);
            if (user.AccountType == "Admin" || user.AccountType == "AdelanteStaff" || user.AccountType == "Grantor")
            {
                return View(donor);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Sorry, you don't have the proper authorization to view this page");
            }
            
        }

        // GET: Donor/Create
        public ActionResult Create()
        {
            if (user.AccountType == "Admin" || user.AccountType == "AdelanteStaff" || user.AccountType == "Grantor")
            {
                return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Sorry, you don't have the proper authorization to view this page");
            }
            
        }

        // POST: Donor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Donor_ID,First_Name,Middle_Initial,Last_Name,Address,City,State,Zip_Code,Email,Phone")] Donor donor)
        {
            if (ModelState.IsValid)
            {
                db.Donors.Add(donor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donor);
        }

        // GET: Donor/Edit/5
        public ActionResult Edit(string id)
        {
            Donor donor = db.Donors.Find(id);
            if (user.AccountType == "Admin" || user.AccountType == "AdelanteStaff" || user.AccountType == "Grantor")
            {
                return View(donor);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Sorry, you don't have the proper authorization to view this page");
            }
            
        }

        // POST: Donor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Donor_ID,First_Name,Middle_Initial,Last_Name,Address,City,State,Zip_Code,Email,Phone")] Donor donor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donor);
        }

        // GET: Donor/Delete/5
        public ActionResult Delete(string id)
        {
            Donor donor = db.Donors.Find(id);
            if (user.AccountType == "Admin" || user.AccountType == "AdelanteStaff" || user.AccountType == "Grantor")
            {
                return View(donor);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Sorry, you don't have the proper authorization to view this page");
            }
        }

        // POST: Donor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Donor donor = db.Donors.Find(id);
            db.Donors.Remove(donor);
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
