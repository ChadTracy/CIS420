using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using AHA_Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace AHA_Web.Controllers
{
    public class UserPortalController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        protected ApplicationDbContext ApplicationDbContext { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }
        private ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

        public UserPortalController()
        {
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
        }


        public ActionResult Index()
        {
            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "You must be logged in to view this content");
            }
            else
            {
                return View();
            }
            
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
        public ActionResult eventListView()
        {
            return View();
        }
    }
}