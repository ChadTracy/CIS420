using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DHTMLX.Scheduler;
using DHTMLX.Scheduler.Data;
using DHTMLX.Common;
using System.Collections.Generic;
using AHA_Web.Models;

namespace AHA_Web.Models
{
    public partial class Event
    {
        [Required]
        public int EventID { get; set; }

        public string text { get; set; }

        public DateTime start_date { get; set; }

        public DateTime end_date { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}