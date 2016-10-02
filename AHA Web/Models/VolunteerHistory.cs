using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [MaxLength(12),MinLength(12)]
        [Column(Order = 1)]
        [Required]
        public string Event_ID { get; set; }

        [Required]
        [Display(Name = "Hours Worked")]
        public int Hours_Worked { get; set; }

        public virtual Event Event { get; set; }

        public virtual Volunteer Volunteer { get; set; }
    }
}