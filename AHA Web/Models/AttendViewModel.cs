using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AHA_Web.Models
{
    public class AttendViewModel
    {
        public UsersViewModel UserModel { get; set; }
        public Event eventEntry{ get;set; }
        public DateTime ClockIn { get; set; }
        public DateTime ClockOut { get; set; }
    }
}