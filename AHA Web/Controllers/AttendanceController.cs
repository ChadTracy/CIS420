using AHA_Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AHA_Web.Controllers
{
    public class AttendanceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Attendance
        public ActionResult Index()
        {
            var attendance = db.Attendance;
            var events = db.Events.Select(e => e.text);
            var eventList = new SelectList(events);
            ViewData.Add("EventID", eventList);
            ViewBag.EventList = eventList;
            return View();
        }

        [HttpPost]
        public ActionResult ClockIn([Bind(Exclude = "SignIn,SignOut", Include ="EventID,Email")]Attendance newAttendance)
        {
            newAttendance.SignIn = DateTime.Now;
            newAttendance.SignOut = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Attendance.Add(newAttendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newAttendance);
        }

        [HttpPost]
        public ActionResult ClockOut([Bind(Exclude = "SignIn,SignOut", Include = "EventID,Email")]Attendance newAttendance)
        {
            newAttendance.SignOut = DateTime.Now;

            if (ModelState.IsValid)
            {
                //db.Attendance.Add(newAttendace);
                db.Entry(newAttendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newAttendance);
        }
    }
}