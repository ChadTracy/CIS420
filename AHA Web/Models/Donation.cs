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
        [Key]
        [Column(Order = 0)]
        [Display(Name = "Transaction ID")]
        public string Transaction_ID { get; set; }

        [Required]
        [Key]
        [Column(Order =1)]
        [MaxLength(9), MinLength(9)]
        [Display(Name = "Donor ID")]
        public string Donor_ID { get; set; }

        [Display(Name = "Amount Donated")]
        [Required]
        [DataType(DataType.Currency, ErrorMessage = "Please Provide a Currency Value")]
        public decimal Donation_Amount { get; set; }

        [MaxLength(20)]
        [Display(Name = "Transaction ID From Provider")]
        public string Transaction_ID_From_Provider { get; set; }

        public virtual Donor Donor { get; set; }
    }
}