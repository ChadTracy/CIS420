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

namespace AHA_Web.Controllers.Grants
{
    public class GrantorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        protected ApplicationDbContext ApplicationDbContext { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }
        private ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

        public GrantorController()
        {
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
        }

        // GET: Grantor
        public ActionResult Index()
        {
            if (user.AccountType == "Admin" || user.AccountType == "Staff" || user.AccountType == "Grantor")
            {
                return View(db.Grantors.ToList());
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

        // GET: Grantor/Details/5
        public ActionResult Details(string id)
        {
            Grantor grantor = db.Grantors.Find(id);
            if (user.AccountType == "Admin" || user.AccountType == "Staff" || user.AccountType == "Grantor")
            {
                return View(grantor);
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
            Grantor grantor = db.Grantors.Find(id);
            if (user.AccountType == "Admin" || user.AccountType == "Staff" || user.AccountType == "Grantor")
            {
                return View(grantor);
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
            Grantor grantor = db.Grantors.Find(id);
            if (user.AccountType == "Admin" || user.AccountType == "Staff" || user.AccountType == "Grantor")
            {
                return View(grantor);
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
