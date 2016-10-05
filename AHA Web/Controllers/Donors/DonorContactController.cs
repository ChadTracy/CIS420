using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AHA_Web.Models;

namespace AHA_Web.Controllers.Donors
{
    public class DonorContactController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DonorContact
        public ActionResult Index()
        {
            var contact = db.Contact.Include(d => d.AdelanteStaff).Include(d => d.Donor);
            return View(contact.ToList());
        }

        // GET: DonorContact/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorContact donorContact = db.Contact.Find(id);
            if (donorContact == null)
            {
                return HttpNotFound();
            }
            return View(donorContact);
        }

        // GET: DonorContact/Create
        public ActionResult Create()
        {
            ViewBag.Staff_ID = new SelectList(db.Staff, "Staff_ID", "First_Name");
            ViewBag.Donor_ID = new SelectList(db.Donors, "Donor_ID", "First_Name");
            return View();
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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorContact donorContact = db.Contact.Find(id);
            if (donorContact == null)
            {
                return HttpNotFound();
            }
            ViewBag.Staff_ID = new SelectList(db.Staff, "Staff_ID", "First_Name", donorContact.Staff_ID);
            ViewBag.Donor_ID = new SelectList(db.Donors, "Donor_ID", "First_Name", donorContact.Donor_ID);
            return View(donorContact);
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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorContact donorContact = db.Contact.Find(id);
            if (donorContact == null)
            {
                return HttpNotFound();
            }
            return View(donorContact);
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
