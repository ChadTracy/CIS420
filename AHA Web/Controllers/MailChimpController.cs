using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MailChimp.Net.Core;
using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;
using MailChimp.Net;
using System.Threading.Tasks;
using AHA_Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace AHA_Web.Controllers
{

    public class MailChimpController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        protected ApplicationDbContext ApplicationDbContext { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }
        private ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

        public MailChimpController()
        {
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
        }
        // GET: MailChimp
        public ActionResult Index()
        {
            if (user.AccountType == "Admin" || user.AccountType == "" +
                "Staff" +
                "" +
                "" +
                "")
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
    }
}