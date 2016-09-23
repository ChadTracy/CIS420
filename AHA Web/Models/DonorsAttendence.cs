using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHA_Web.Models
{
    public partial class DonorsAttendence
    {

        public string Donor_ID { get; set; }


        public string Event_ID { get; set; }

        public TimeSpan? Sign_In_Time { get; set; }

        public TimeSpan? Sign_Out_Time { get; set; }

        public virtual Donor Donor { get; set; }

        public virtual Event Event { get; set; }
    }
}