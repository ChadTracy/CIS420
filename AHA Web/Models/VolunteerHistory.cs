using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AHA_web.Models;

namespace AHA_Web.Models
{
    public partial class VolunteerHistory
    {

        [Key]
        [Display(Name = "Volunteer ID")]
        [MaxLength(11),MinLength(11)]
        [Column(Order = 0)]
        [Required]
        public string Volunteer_ID { get; set; }

        [Key]
        [Display(Name = "Event ID")]
        [Column(Order = 1)]
        [Required]
        public string EventID { get; set; }

        [Required]
        [Display(Name = "Hours Worked")]
        public int Hours_Worked { get; set; }

        public virtual Event Event { get; set; }

        public virtual Volunteer Volunteer { get; set; }
    }
}