using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHA_Web.Models
{
    public partial class StudentAttendence
    {

        public string Student_ID { get; set; }

        public string Event_ID { get; set; }

        public TimeSpan? Sign_in_Time { get; set; }

        public TimeSpan? Sign_Out_Time { get; set; }

        public virtual Event Event { get; set; }

        public virtual Student Student { get; set; }
    }
}