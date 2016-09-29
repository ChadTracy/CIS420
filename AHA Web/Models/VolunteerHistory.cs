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

        [Required]
        [Key, Column(Order = 0)]
        public string Volunteer_ID { get; set; }

        [Required]
        [Key, Column(Order = 1)]
        public string Event_ID { get; set; }

        [Required]
        public int Hours_Worked { get; set; }

       
        public virtual Event Event { get; set; }

        public virtual Volunteer Volunteer { get; set; }
    }
}