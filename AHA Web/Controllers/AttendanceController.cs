using AHA_Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace AHA_Web.Controllers
{
    public class AttendanceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        protected ApplicationDbContext ApplicationDbContext { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }
        private ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

        public AttendanceController()
        {
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
        }


        // GET: Attendance
        public ActionResult Index()
        {
            if (user.AccountType == "Admin" || user.AccountType == "Staff")
            {
                var attendance = db.Attendance;
                var eventList = new SelectList(db.Events, "EventID", "text");
                ViewData.Add("EventID", eventList);
                ViewBag.EventList = eventList;
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

        [HttpPost]
        public ActionResult ClockIn([Bind(Exclude = "SignIn,SignOut", Include = "EventID,Email")]Attendance newAttendance)
        {
            newAttendance.SignIn = DateTime.Now;
            newAttendance.SignOut = null;
            if (newAttendance.Email == null || newAttendance.Email == "")
                return RedirectToAction("Index");
            if (ModelState.IsValid)
            {
                db.Attendance.AddOrUpdate(newAttendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newAttendance);
        }
        public ActionResult ViewAttendance(string id)
        {
            //Get event by ID
            Event tEvent = db.Events.Find(Int32.Parse(id));
            //Get list of users
            List<UsersViewModel> users = AccountController.GetEssentialUserData();
            List<AttendViewModel> enrolledUsers = new List<AttendViewModel>();
            //Iterate through the list of users, if attendance table contains (EventID, UserID), add that user to return list
            foreach(var v in db.Attendance)
            {
                //Limit to items that have the same eID
                if(v.EventID==id)
                {
                    AttendViewModel attend = new AttendViewModel();
                    attend.UserModel=users.Find(u =>u.Email==v.Email);
                    attend.eventEntry = tEvent;
                    if (v.SignIn != null)
                        attend.ClockIn = (DateTime)v.SignIn;
                    else
                        attend.ClockIn = new DateTime(1900, 01, 01);
                    if (v.SignOut != null)
                        attend.ClockOut = (DateTime)v.SignOut;
                    else
                        attend.ClockOut = new DateTime(1900, 01, 01);
                    enrolledUsers.Add(attend);
                }
            }
            return View(enrolledUsers);
        }

        [HttpPost]
        public ActionResult ClockOut([Bind(Exclude = "SignIn, SignOut", Include = "EventID,Email")]Attendance newAttendance)
        {
            if (newAttendance.Email == null || newAttendance.Email == "")
                return RedirectToAction("Index");
            Attendance currentSignIn = db.Attendance.Find(newAttendance.EventID, newAttendance.Email);
            newAttendance.SignOut = DateTime.Now;
            newAttendance.SignIn=currentSignIn.SignIn;
            
            if (ModelState.IsValid)
            {
                //db.Attendance.Add(newAttendace);
                db.Attendance.Remove(currentSignIn);
                db.Attendance.Add(newAttendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newAttendance);
        }
    }
}