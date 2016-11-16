using System;
using System.Linq;
using System.Web.Mvc;
using AHA_Web.Models;
using DHTMLX.Common;
using DHTMLX.Scheduler;
using DHTMLX.Scheduler.Data;
using System.Collections.Generic;

namespace AHA_Web.Controllers
{
    public class EventController : Controller
    {
        //Refer to this link in order to set up the Calendar.
        //http://scheduler-net.com/docs/simple-.net-mvc-application-with-scheduler.html#step_2_add_the_scheduler_reference

        public readonly AHA_Web.Models.ApplicationDbContext _db = new AHA_Web.Models.ApplicationDbContext();

        public ActionResult Index()
        {
            var scheduler = new DHXScheduler(this); //initializes dhtmlxScheduler
            scheduler.LoadData = true;// allows loading data
            scheduler.EnableDataprocessor = true;// enables DataProcessor in order to enable implementation CRUD operations
            return View(scheduler);
        }

        public ActionResult Data()
        {
            //events for loading to scheduler
            return new SchedulerAjaxData(_db.Events);
        }
        public ActionResult ListView()
        {
            List<Attendance> aList = new List<Attendance>();
            aList = _db.Attendance.ToList();
            List<Event> returnlist = new List<Event>();

            //Return a list of events that only have attendance
            foreach (var e in _db.Events)
            {
                bool attendanceContains;
                //check to see if the ID of e is in any of a list
                foreach (var a in aList)
                {
                    if (a.EventID == e.EventID.ToString())
                        attendanceContains = true;
                }
                returnlist.Add(e);
            }
            return View(returnlist);
        }

        public ActionResult Save(Event updatedEvent, FormCollection formData)
        {
            var action = new DataAction(formData);

            try
            {
                switch (action.Type)
                {
                    case DataActionTypes.Insert: // your Insert logic
                        _db.Events.Add(updatedEvent);
                        break;
                    case DataActionTypes.Delete: // your Delete logic
                        updatedEvent = _db.Events.SingleOrDefault(ev => ev.EventID == updatedEvent.EventID);
                        _db.Events.Remove(updatedEvent);
                        break;
                    default:// "update" // your Update logic
                        updatedEvent = _db.Events.SingleOrDefault(
                        ev => ev.EventID == updatedEvent.EventID);
                        UpdateModel(updatedEvent);
                        break;
                }
                _db.SaveChanges();
                action.TargetId = updatedEvent.EventID;
            }
            catch (Exception ex)
            {
                action.Type = DataActionTypes.Error;
            }
            return (new AjaxSaveResponse(action));
        }
    }
}