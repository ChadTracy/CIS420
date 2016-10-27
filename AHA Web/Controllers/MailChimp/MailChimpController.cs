using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AHA_Web.MailChimp;
using System.Net;

namespace AHA_Web.Controllers.MailChimp
{
    public class MailChimpController : Controller
    {
        AHA_Web.MailChimp.MailChimp mc = new AHA_Web.MailChimp.MailChimp();

        // GET: MailChimp
        public ActionResult Index()
        {
            List<List> allLists = mc.getAllLists().lists;
            ViewBag.lists = allLists;

            return View();
        }

        public ActionResult List(string listID)
        {
            if (listID == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Members members = mc.getListMembers(listID);
            if (members == null)
                return HttpNotFound();
            ViewBag.members = members.members;

            return View();
        }
    }
}