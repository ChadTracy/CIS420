using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHA_Web.Models
{
    public partial class VolunteerHistory
    {

        public string Volunteer_ID { get; set; }


        public string Event_ID { get; set; }

        public int Hours_Worked { get; set; }

        public virtual Event Event { get; set; }

        public virtual Volunteer Volunteer { get; set; }
    }
}