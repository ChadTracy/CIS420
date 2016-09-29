using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AHA_Web.Models
{
    public partial class Event
    {

        public Event()
        {
            DonorsAttendences = new HashSet<DonorsAttendence>();
            VolunteerHistories = new HashSet<VolunteerHistory>();
            StudentAttendences = new HashSet<StudentAttendence>();
        }
        [Required]
        [Key]
        public string Event_ID { get; set; }

        [Required]
        public string Event_Name { get; set; }

        public decimal? Attendence_Cost { get; set; }

        [Required]
        public string Event_Type { get; set; }

        [Required]
        public DateTime? Event_Date { get; set; }
        [Required]
        public TimeSpan? Event_Time { get; set; }


        public virtual ICollection<DonorsAttendence> DonorsAttendences { get; set; }


        public virtual ICollection<VolunteerHistory> VolunteerHistories { get; set; }


        public virtual ICollection<StudentAttendence> StudentAttendences { get; set; }
    }
}