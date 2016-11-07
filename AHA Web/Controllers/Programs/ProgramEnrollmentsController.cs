using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AHA_Web.Models;

namespace AHA_Web.Controllers.Programs
{
    public class ProgramEnrollmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProgramEnrollments
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProgramEnrollments/Details/5
        public ActionResult Details(string id)
        {
            return View();
        }
        public ActionResult LandingPageView()
        {
            var db = new ApplicationDbContext();
            IEnumerable<SelectListItem> items = db.Events
              .Select(e => new SelectListItem
              {
                  Value = e.EventID.ToString(),
                  Text = e.text
              });
            ViewBag.Events = items;
            IEnumerable<SelectListItem> progs = db.Programs
              .Select(p => new SelectListItem
              {
                  Value = p.Program_ID.ToString(),
                  Text = p.Program_Name
              });
            ViewBag.Programs = progs;
            return View();
        }
        public ActionResult EnrollStudent(string id)
        {
            var db = new ApplicationDbContext();
            //create a list of all users
            List<UsersViewModel> users = AccountController.GetEssentialUserData();
            //Create a list of program enrollments
            List<ProgramEnrollment> allEnrollments = db.ProgramEnrollment.ToList();
            //Create a lookup list for return
            List < EnrollStudentViewModel > returnList= new List<EnrollStudentViewModel>();
            //find all student IDs that are already enrolled in the current program
            List<string> enrolledIDs = new List<String>();
            foreach(var v in allEnrollments)
            {
                //Only look at IDs that match the program ID
                if(v.Program_ID==id)
                {
                    enrolledIDs.Add(v.AccountID); //Add the already registed account Id to the exclusion list
                }
            } //By now you have a list of all ID's that are already registered
            
            //Parse through all the users to build the model for the view
            foreach (var v in users)
            {
                //check if user is not in the list of enrollments
                if(!enrolledIDs.Contains(v.Id))
                {
                    //Build a program enrollment model 
                    EnrollStudentViewModel emodel=new EnrollStudentViewModel();
                    emodel.Program_ID = id;
                    emodel.UserModel = v;
                    returnList.Add(emodel);
                }
            }
            if(returnList.Count!=0) //If returnlist is not empty
            {
                return View(returnList);
            }
            else
                return RedirectToAction("Index", "Program");

        }
        //Action result for managing enrollments
        public ActionResult ManageEnrollments(string id)
        {
            var db = new ApplicationDbContext();
            //create a list of all users
            List<UsersViewModel> users = AccountController.GetEssentialUserData();
            //Create a list of program enrollments
            List<ProgramEnrollment> allEnrollments = db.ProgramEnrollment.ToList();
            //Create a lookup list for return
            List<EnrollStudentViewModel> returnList = new List<EnrollStudentViewModel>();
            //find all student IDs that are already enrolled in the current program
            List<string> enrolledIDs = new List<String>();
            foreach (var v in allEnrollments)
            {
                //Only look at IDs that match the program ID
                if (v.Program_ID == id)
                {
                    enrolledIDs.Add(v.AccountID); //Add the already registed account Id to the exclusion list
                }
            } //By now you have a list of all ID's that are already registered
              //Parse through all the users to build the model for the view
            foreach (var v in users)
            {
                //check if user is in the list of enrollments
                if (enrolledIDs.Contains(v.Id))
                {
                    //Build a program enrollment model 
                    EnrollStudentViewModel emodel = new EnrollStudentViewModel();
                    emodel.Program_ID = id;
                    emodel.UserModel = v;
                    returnList.Add(emodel);
                }
            }
            if (returnList.Count != 0) //If returnlist is not empty
            {
                return View(returnList);
            }
            else
                return RedirectToAction("Index", "Program");
        }

        // GET: ProgramEnrollments/Create
        public ActionResult Create()
        {
            ViewBag.Program_ID = new SelectList(db.Programs, "Program_ID", "Program_Name");
            return View();
        }
        //Action that performs actual enrollment
        public ActionResult EnrollStudentAction(string programID, string userID)
        {
            if(programID!=null&&userID!=null)
            {
                ProgramEnrollment enrollItem = new ProgramEnrollment();
                enrollItem.AccountID = userID;
                enrollItem.Program_ID = programID;
                db.ProgramEnrollment.Add(enrollItem);
                db.SaveChanges();
            }
            //Return a redirect to the prior screen
            return RedirectToAction("EnrollStudent", "ProgramEnrollments", new { id = programID});
        }

        public ActionResult UnenrollStudentAction(string programID, string userID)
        {
            if (programID != null && userID != null)
            {
                ProgramEnrollment a=db.ProgramEnrollment.Find(programID, userID);
                db.ProgramEnrollment.Remove(a);
                db.SaveChanges();
            }
            //Return a redirect to the prior screen
            return RedirectToAction("ManageEnrollments", "ProgramEnrollments", new { id = programID });
        }

        // POST: ProgramEnrollments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Enrollment_Number,StudentEmail,Program_ID,EventID,StartTime,EndTime,Attended")] ProgramEnrollment programEnrollment)
        {
            if (ModelState.IsValid)
            {
                db.ProgramEnrollment.Add(programEnrollment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Program_ID = new SelectList(db.Programs, "Program_ID", "Program_Name", programEnrollment.Program_ID);
            return View(programEnrollment);
        }

        // GET: ProgramEnrollments/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramEnrollment programEnrollment = db.ProgramEnrollment.Find(id);
            if (programEnrollment == null)
            {
                return HttpNotFound();
            }
            ViewBag.Program_ID = new SelectList(db.Programs, "Program_ID", "Program_Name", programEnrollment.Program_ID);
            return View(programEnrollment);
        }

        // POST: ProgramEnrollments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Enrollment_Number,StudentEmail,Program_ID,EventID,StartTime,EndTime,Attended")] ProgramEnrollment programEnrollment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(programEnrollment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Program_ID = new SelectList(db.Programs, "Program_ID", "Program_Name", programEnrollment.Program_ID);
            return View(programEnrollment);
        }

        // GET: ProgramEnrollments/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramEnrollment programEnrollment = db.ProgramEnrollment.Find(id);
            if (programEnrollment == null)
            {
                return HttpNotFound();
            }
            return View(programEnrollment);
        }

        // POST: ProgramEnrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ProgramEnrollment programEnrollment = db.ProgramEnrollment.Find(id);
            db.ProgramEnrollment.Remove(programEnrollment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
