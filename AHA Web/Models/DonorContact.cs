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
        [Key]
        [Required]
        [Column(Order = 0)]
        [MaxLength(9)]
        [Display(Name = "Donor ID")]
        public string Donor_ID { get; set; }

        [Key]
        [Required]
        [Column(Order = 1)]
        [MaxLength(6)]
        [Display(Name = "Staff ID")]
        public string Staff_ID { get; set; }

        [Required]
        [Display(Name = "Contact Date")]
        [DataType(DataType.Date, ErrorMessage= "Please Enter a Valid Date")]    
        public DateTime Date { get; set; }

        [MaxLength(10), MinLength(5)]
        [Display(Name = "Contact Method")]
        public string Method_Of_Contact { get; set; }

        public virtual AdelanteStaff AdelanteStaff { get; set; }

        public virtual Donor Donor { get; set; }
    }
}