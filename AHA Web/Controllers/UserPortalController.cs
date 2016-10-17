using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using AHA_Web.Models;

namespace AHA_Web.Controllers
{
    public class UserPortalController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AccountManagement()
        {
            return View();
        }
        public ActionResult CreateEvent()
        {
            return View();
        }
        public ActionResult EditEvents()
        {
            return View();
        }
        public ActionResult ViewCalendar()
        {
            return View();
        }
        
    }
}