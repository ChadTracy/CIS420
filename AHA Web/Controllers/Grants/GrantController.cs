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
    public class GrantController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        protected ApplicationDbContext ApplicationDbContext { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }
        private ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

        public GrantController()
        {
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
        }

        // GET: Grant
        public ActionResult Index()
        {
            if (user.AccountType == "Admin" || user.AccountType == "Staff" || user.AccountType == "Grantor" || user.AccountType == "BoardMember")
            {
                var grants = db.Grants.Include(g => g.Grantor);
                return View(grants);
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

        // GET: Grant/Details/5
        public ActionResult Details(string id)
        {
            Grant grant = db.Grants.Find(id);
            if (user.AccountType == "Admin" || user.AccountType == "Staff" || user.AccountType == "Grantor" || user.AccountType == "BoardMember")
            {
                return View(grant);
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

        // GET: Grant/Create
        public ActionResult Create()
        {
            if (user.AccountType == "Admin" || user.AccountType == "Staff" || user.AccountType == "Grantor" || user.AccountType == "BoardMember")
            {
                ViewBag.Grantor_ID = new SelectList(db.Grantors, "Grantor_ID", "Organization");
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
            Grant grant = db.Grants.Find(id);
            if (user.AccountType == "Admin" || user.AccountType == "Staff" || user.AccountType == "Grantor" || user.AccountType == "BoardMember")
            {
                ViewBag.Grantor_ID = new SelectList(db.Grantors, "Grantor_ID", "Organization");
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
            Grant grant = db.Grants.Find(id);
            if (user.AccountType == "Admin" || user.AccountType == "Staff" || user.AccountType == "Grantor" || user.AccountType == "BoardMember")
            {
                return View(grant);
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
            if (user.AccountType == "Admin" || user.AccountType == "Staff" || user.AccountType == "Grantor" || user.AccountType == "BoardMember")
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

        public ActionResult EditGrants()
        {
            if (user.AccountType == "Admin" || user.AccountType == "Staff" || user.AccountType == "Grantor" || user.AccountType == "BoardMember")
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

        public ActionResult ViewGrants()
        {
            if (user.AccountType == "Admin" || user.AccountType == "Staff" || user.AccountType == "Grantor" || user.AccountType == "BoardMember")
            {
                var grants = db.Grants.Include(g => g.Grantor);
                return View(grants);
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
    }
}