using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AHA_Web.Models
{
    public partial class Donation
    {
        [Required]
        [Key, Column(Order = 0)]
        public string Transaction_ID { get; set; }

        [Required]
        [Key, Column(Order = 1)]
        public string Donor_ID { get; set; }

        [Required]
        public decimal Donation_Amount { get; set; }

        
        public string Transaction_ID_From_Provider { get; set; }

       
        public virtual Donor Donor { get; set; }
    }
}