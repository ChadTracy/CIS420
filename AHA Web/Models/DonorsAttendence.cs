using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AHA_web.Models;

namespace AHA_Web.Models
{
    public partial class DonorsAttendence
    {
        [Key]
        [Column(Order = 0)]
        [MaxLength(9), MinLength(9)]
        [Display(Name ="Donor ID")]
        public string Donor_ID { get; set; }

        [Key]
        [Column(Order =1)]
        [Display(Name = "Event ID")]
        public string EventID { get; set; }

        [DataType(DataType.Time,ErrorMessage ="Please Enter a Valid Time")]
        [Display(Name = "Sign In Time")]
        public TimeSpan? Sign_In_Time { get; set; }

        [DataType(DataType.Time, ErrorMessage = "Please Enter a Valid Time")]
        [Display(Name = "Sign Out Time")]
        public TimeSpan? Sign_Out_Time { get; set; }

        public virtual Donor Donor { get; set; }

        public virtual Event Events { get; set; }
    }
}