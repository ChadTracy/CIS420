using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;
using System.Data.Entity;

using DHTMLX.Scheduler;
using DHTMLX.Scheduler.Data;
using DHTMLX.Common;

using AHA_Web.Models;

namespace AHA_Web.Controllers
{
    public class HomeController : Controller
    {
        private Event db = new Event();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Programs()
        {

            return View();
        }

        public ActionResult Students()
        {

            return View();
        }

        public ActionResult GetInvolved()
        {

            return View();
        }

        public ActionResult Sponsors()
        {

            return View();
        }

        public ActionResult StudentOfMonth()
        {

            return View();
        }
        public ActionResult MentoringEnrichment()
        {
            return View();
        }
        public ActionResult CollegeReadiness() { return View(); }
        public ActionResult AST() { return View(); }
        public ActionResult ParentInvolvement() { return View(); }
        public ActionResult Ambassadors() { return View(); }
        public ActionResult TJXScholarship() { return View(); }
        public ActionResult BAM() { return View(); }


        private readonly DbContext _db = new ApplicationDbContext();

        public ActionResult Calendar()
        {
            var scheduler = new DHXScheduler(this);
            scheduler.Skin = DHXScheduler.Skins.Flat;

            scheduler.Config.first_hour = 6;
            scheduler.Config.last_hour = 20;

            scheduler.LoadData = true;
            scheduler.EnableDataprocessor = true;

            return View(scheduler);
        }

        public ContentResult Data(DateTime from, DateTime to)
        {
            var apps = _db.Set<Event>().Where(e => e.Event_Start_Date < to && e.Event_End_Date >= from).ToList();
            return new SchedulerAjaxData(apps);
        }

        public ContentResult Data()
        {
            var apps = _db.Set<Event>().ToList();
            return new SchedulerAjaxData(apps);
        }

        public ActionResult Save(int? id, FormCollection actionValues)
        {
            var action = new DataAction(actionValues);

            try
            {
                var changedEvent = DHXEventsHelper.Bind<Event>(actionValues);
                switch (action.Type)
                {
                    case DataActionTypes.Insert:
                        Event EV = new Event();
                        EV.Event_Start_Date = changedEvent.Event_Start_Date;
                        EV.Event_End_Date = changedEvent.Event_End_Date;
                        EV.Description = changedEvent.Description;
                        _db.Set<Event>().Add(EV);
                        _db.SaveChanges();
                        
                        break;
                }
                _db.SaveChanges();
                action.TargetId = Convert.ToInt64(changedEvent.Event_ID);
            }
            catch (Exception)
            {
                action.Type = DataActionTypes.Error;
            }

            return (new AjaxSaveResponse(action));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}