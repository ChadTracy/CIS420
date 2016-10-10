using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AHA_Web.Models;

namespace AHA_Web.Controllers.BoardMembers
{
    public class BoardMemberController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BoardMember
        public ActionResult Index()
        {
            return View(db.BoardMember.ToList());
        }

        // GET: BoardMember/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardMember boardMember = db.BoardMember.Find(id);
            if (boardMember == null)
            {
                return HttpNotFound();
            }
            return View(boardMember);
        }

        // GET: BoardMember/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BoardMember/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BM_ID,First_Name,Middle_Initial,Last_Name,Address,City,State,Zip,Phone,Email,Affiliated_Organization")] BoardMember boardMember)
        {
            if (ModelState.IsValid)
            {
                db.BoardMember.Add(boardMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(boardMember);
        }

        // GET: BoardMember/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardMember boardMember = db.BoardMember.Find(id);
            if (boardMember == null)
            {
                return HttpNotFound();
            }
            return View(boardMember);
        }

        // POST: BoardMember/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BM_ID,First_Name,Middle_Initial,Last_Name,Address,City,State,Zip,Phone,Email,Affiliated_Organization")] BoardMember boardMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boardMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(boardMember);
        }

        // GET: BoardMember/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardMember boardMember = db.BoardMember.Find(id);
            if (boardMember == null)
            {
                return HttpNotFound();
            }
            return View(boardMember);
        }

        // POST: BoardMember/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BoardMember boardMember = db.BoardMember.Find(id);
            db.BoardMember.Remove(boardMember);
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
