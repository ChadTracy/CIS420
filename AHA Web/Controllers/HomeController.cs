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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
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
    }
}