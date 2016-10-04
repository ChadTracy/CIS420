using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using DHTMLX.Scheduler;
using DHTMLX.Scheduler.Data;
using DHTMLX.Common;

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
        [Display(Name = "Event ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Event_ID { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Event Title")]
        public string Event_Name { get; set; }

        [Required]
        [Display(Name = "Attendence Cost")]
        [DataType(DataType.Currency, ErrorMessage = "Please Provide a Currency Value")]
        public decimal? Attendence_Cost { get; set; }

        [Required]
        [Display(Name = "Type of Event")]
        [MaxLength(20)] 
        public string Event_Type { get; set; }

        [Required]
        [Display(Name = "Starting Date")]
        [DataType(DataType.Date, ErrorMessage ="Please Enter a Valid Date")]
        public DateTime? Event_Start_Date { get; set; }

        [Display(Name = "Ending Date")]
        [DataType(DataType.Date, ErrorMessage = "Please Enter a Valid Date")]
        public DateTime? Event_End_Date { get; set; }

        [Required]
        [DataType(DataType.Time,ErrorMessage = "Please Enter a Valid Time")]
        public TimeSpan? Event_Time { get; set; }


        public virtual ICollection<DonorsAttendence> DonorsAttendences { get; set; }


        public virtual ICollection<VolunteerHistory> VolunteerHistories { get; set; }


        public virtual ICollection<StudentAttendence> StudentAttendences { get; set; }
    }
}