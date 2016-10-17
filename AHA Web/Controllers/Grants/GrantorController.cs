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
    public class GrantorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Grantor
        public ActionResult Index()
        {
            return View(db.Grantors.ToList());
        }

        // GET: Grantor/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grantor grantor = db.Grantors.Find(id);
            if (grantor == null)
            {
                return HttpNotFound();
            }
            return View(grantor);
        }

        // GET: Grantor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Grantor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Grantor_ID,Organization,Address,City,State,Zip_Code,Email,Phone")] Grantor grantor)
        {
            if (ModelState.IsValid)
            {
                db.Grantors.Add(grantor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grantor);
        }

        // GET: Grantor/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grantor grantor = db.Grantors.Find(id);
            if (grantor == null)
            {
                return HttpNotFound();
            }
            return View(grantor);
        }

        // POST: Grantor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Grantor_ID,Organization,Address,City,State,Zip_Code,Email,Phone")] Grantor grantor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grantor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grantor);
        }

        // GET: Grantor/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grantor grantor = db.Grantors.Find(id);
            if (grantor == null)
            {
                return HttpNotFound();
            }
            return View(grantor);
        }

        // POST: Grantor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Grantor grantor = db.Grantors.Find(id);
            db.Grantors.Remove(grantor);
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
