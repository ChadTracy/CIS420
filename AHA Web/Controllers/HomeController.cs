using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Data;
using System.Data.Entity;
using DHTMLX.Scheduler;
using DHTMLX.Scheduler.Data;
using DHTMLX.Common;
using reCAPTCHA.MVC;
using AHA_Web.Models;
using System.Net;
using System.IO;

namespace AHA_Web.Controllers
{
    public class HomeController : Controller
    {
        public readonly AHA_Web.Models.ApplicationDbContext _db = new AHA_Web.Models.ApplicationDbContext();

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

        public ActionResult PrivacyPolicy()
        {
            return View();
        }

        public ActionResult CollegeReadiness() { return View(); }
        public ActionResult AST() { return View(); }
        public ActionResult ParentInvolvement() { return View(); }
        public ActionResult Ambassadors() { return View(); }
        public ActionResult TJXScholarship() { return View(); }
        public ActionResult BAM() { return View(); }
        public ActionResult Calendar()
        {
            var scheduler = new DHXScheduler(this); //initializes dhtmlxScheduler
            scheduler.LoadData = true;// allows loading data
            scheduler.EnableDataprocessor = true;// enables DataProcessor in order to enable implementation CRUD operations
            scheduler.Config.isReadonly = true;
            return View(scheduler);
        }
        public ActionResult Data()
        {
            //events for loading to scheduler
            return new SchedulerAjaxData(_db.Events);
        }

        [HttpPost]
        /*  [CaptchaValidator(
  PrivateKey = "6Lcd6wcUAAAAALyfSPaS1UOZADXj6eDcFNCgqcUa",
  ErrorMessage = "Invalid input captcha.",
  RequiredMessage = "The captcha field is required.")] */

        public ActionResult Contact(MailViewModel Model)
        {
            if (ModelState.IsValid)
            {
                var toEmail = "ahawebconfig@gmail.com";
                var toEmailPassword = "ahawebconfig123";
                string Body = Model.Message;

                MailMessage mail = new MailMessage();
                mail.To.Add(toEmail);
                mail.From = new MailAddress(Model.Email);
                mail.Subject = "Contact Form Submission";
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();

                //SMTP settings when running locally (uses gmail)
                //smtp.Host = "smtp.gmail.com";
                //smtp.Port = 587;
                //smtp.EnableSsl = true;
                //Setup credentials to login to our sender email address ("UserName", "Password")
                //NetworkCredential credentials = new NetworkCredential(toEmail, toEmailPassword);
                //smtp.UseDefaultCredentials = false;
                //smtp.Credentials = credentials;

                //Production settings        
                smtp.EnableSsl = false;
                smtp.Host = "relay-hosting.secureserver.net";
                smtp.Port = 25;

                smtp.Send(mail);

                return View("~/Views/Home/ThankYou.cshtml"); // TODO: make thank you page
            }
            else
            {
                return View("~/Views/Home/Error.cshtml"); //TODO: make error page
            }

        }
    }
}