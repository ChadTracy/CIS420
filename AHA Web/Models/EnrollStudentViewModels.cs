using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AHA_Web.Models
{
    public class EnrollStudentViewModel
    {
        public UsersViewModel UserModel { get; set; }
        public string Program_ID { get; set; }
    }
}