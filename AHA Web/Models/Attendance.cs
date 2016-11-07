using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AHA_Web.Models
{
    public class Attendance
    {
        [Key]
        [Column(Order = 0)]
        public string Event_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        public string User_ID { get; set; }

        public DateTime ClockIn {get; set;}
        public DateTime ClockOut {get; set;}
    }
}