using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AHA_Web.Models
{
    public partial class DonorContact
    {
        [Required]
        [Key,Column(Order = 0)]
        public string Donor_ID { get; set; }

        [Required]
        [Key,Column(Order = 1)]
        public string Staff_ID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Method_Of_Contact { get; set; }

        public virtual AdelanteStaff AdelanteStaff { get; set; }

        public virtual Donor Donor { get; set; }
    }
}