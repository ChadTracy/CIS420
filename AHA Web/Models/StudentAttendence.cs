using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AHA_Web.Models
{
    public partial class StudentAttendence
    {

        [Required]
        [Key, Column(Order = 0)]
        public string Student_ID { get; set; }

        [Required]
        [Key, Column(Order = 1)]
        public string Event_ID { get; set; }


        public TimeSpan? Sign_in_Time { get; set; }

        public TimeSpan? Sign_Out_Time { get; set; }

        public virtual Event Event { get; set; }

        public virtual Student Student { get; set; }
    }
}