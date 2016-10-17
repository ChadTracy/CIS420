using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MailChimp.Net.Core;
using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;
using MailChimp.Net;
using System.Threading.Tasks;
using AHA_Web.Models;

namespace AHA_Web.Controllers
{

    public class MailChimpController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: MailChimp
        public ActionResult Index()
        {
            return View();
        }
    }
}