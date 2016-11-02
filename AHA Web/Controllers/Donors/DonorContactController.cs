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
    public class DonorContactController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        protected ApplicationDbContext ApplicationDbContext { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }
        private ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

        public DonorContactController()
        {
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
        }


        // GET: DonorContact
        public ActionResult Index()
        {
            if (user.AccountType == "Admin" || user.AccountType == "AdelanteStaff" || user.AccountType == "Grantor")
            {
                var contact = db.Contact.Include(d => d.AdelanteStaff).Include(d => d.Donor);
                return View(contact.ToList());
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Sorry, you don't have the proper authorization to view this page");
            }

        }

        // GET: DonorContact/Details/5
        public ActionResult Details(string id)
        {
            DonorContact donorContact = db.Contact.Find(id);
            if (user.AccountType == "Admin" || user.AccountType == "AdelanteStaff" || user.AccountType == "Grantor")
            {
                return View(donorContact);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Sorry, you don't have the proper authorization to view this page");
            }
            
        }

        // GET: DonorContact/Create
        public ActionResult Create()
        {
            if (user.AccountType == "Admin" || user.AccountType == "AdelanteStaff" || user.AccountType == "Grantor")
            {
                ViewBag.Staff_ID = new SelectList(db.Staff, "Staff_ID", "First_Name");
                ViewBag.Donor_ID = new SelectList(db.Donors, "Donor_ID", "First_Name");
                return View(); 
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Sorry, you don't have the proper authorization to view this page");
            }

        }

        // POST: DonorContact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Donor_ID,Staff_ID,Date,Method_Of_Contact")] DonorContact donorContact)
        {
            if (ModelState.IsValid)
            {
                db.Contact.Add(donorContact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Staff_ID = new SelectList(db.Staff, "Staff_ID", "First_Name", donorContact.Staff_ID);
            ViewBag.Donor_ID = new SelectList(db.Donors, "Donor_ID", "First_Name", donorContact.Donor_ID);
            return View(donorContact);
        }

        // GET: DonorContact/Edit/5
        public ActionResult Edit(string id)
        {
            DonorContact donorContact = db.Contact.Find(id);
            if (user.AccountType == "Admin" || user.AccountType == "AdelanteStaff" || user.AccountType == "Grantor")
            {
                ViewBag.Staff_ID = new SelectList(db.Staff, "Staff_ID", "First_Name", donorContact.Staff_ID);
                ViewBag.Donor_ID = new SelectList(db.Donors, "Donor_ID", "First_Name", donorContact.Donor_ID);
                return View(donorContact);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Sorry, you don't have the proper authorization to view this page");
            }

        }

        // POST: DonorContact/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Donor_ID,Staff_ID,Date,Method_Of_Contact")] DonorContact donorContact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donorContact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Staff_ID = new SelectList(db.Staff, "Staff_ID", "First_Name", donorContact.Staff_ID);
            ViewBag.Donor_ID = new SelectList(db.Donors, "Donor_ID", "First_Name", donorContact.Donor_ID);
            return View(donorContact);
        }

        // GET: DonorContact/Delete/5
        public ActionResult Delete(string id)
        {
            DonorContact donorContact = db.Contact.Find(id);
            if (user.AccountType == "Admin" || user.AccountType == "AdelanteStaff" || user.AccountType == "Grantor")
            {
                return View(donorContact);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Sorry, you don't have the proper authorization to view this page");
            }

            
        }

        // POST: DonorContact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DonorContact donorContact = db.Contact.Find(id);
            db.Contact.Remove(donorContact);
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
