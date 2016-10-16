using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AHA_Web.Models;

namespace AHA_Web.Controllers.Grants
{
    public class GrantController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Grant
        public ActionResult Index()
        {
            var grants = db.Grants.Include(g => g.Grantor);
            return View(grants);
        }

        // GET: Grant/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grant grant = db.Grants.Find(id);
            if (grant == null)
            {
                return HttpNotFound();
            }
            return View(grant);
        }

        // GET: Grant/Create
        public ActionResult Create()
        {
            ViewBag.Grantor_ID = new SelectList(db.Grantors, "Grantor_ID", "Organization");
            return View();
        }

        // POST: Grant/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Grant_ID,Grantor_ID,Grant_Name,Grant_Due_Date,Grant_Amount,Grant_Type,Grant_status,Author")] Grant grant)
        {
            if (ModelState.IsValid)
            {
                db.Grants.Add(grant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Grantor_ID = new SelectList(db.Grantors, "Grantor_ID", "Organization", grant.Grantor_ID);
            return View(grant);
        }

        // GET: Grant/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grant grant = db.Grants.Find(id);
            if (grant == null)
            {
                return HttpNotFound();
            }
            ViewBag.Grantor_ID = new SelectList(db.Grantors, "Grantor_ID", "Organization", grant.Grantor_ID);
            return View(grant);
        }

        // POST: Grant/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Grant_ID,Grantor_ID,Grant_Name,Grant_Due_Date,Grant_Amount,Grant_Type,Grant_status,Author")] Grant grant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Grantor_ID = new SelectList(db.Grantors, "Grantor_ID", "Organization", grant.Grantor_ID);
            return View(grant);
        }

        // GET: Grant/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grant grant = db.Grants.Find(id);
            if (grant == null)
            {
                return HttpNotFound();
            }
            return View(grant);
        }

        // POST: Grant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Grant grant = db.Grants.Find(id);
            db.Grants.Remove(grant);
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

        public ActionResult CreateGrant()
        {
            return View();
        }

        public ActionResult EditGrants()
        {
            return View();
        }

        public ActionResult ViewGrants()
        {
            var grants = db.Grants.Include(g => g.Grantor);
            return View(grants);
        }
    }
}