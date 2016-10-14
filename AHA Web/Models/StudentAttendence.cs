using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AHA_web.Models;

namespace AHA_Web.Models
{
    public partial class StudentAttendence
    {

        [Key]
        [Display(Name = "Student ID")]
        [Column(Order = 0)]
        [MaxLength(12),MinLength(12)]
        public string Student_ID { get; set; }

        [Key]
        [Display(Name = "Event ID")]
        [Column(Order = 1)]
        public string Program_ID { get; set; }

        [Required]
        [Display(Name = "Sign-in Time")]
        [DataType(DataType.Time,ErrorMessage = "Please Enter a Valid Sign-In Time")]
        public TimeSpan? Sign_in_Time { get; set; }

        [Required]
        [Display(Name = "Sign-Out Time")]
        [DataType(DataType.Time, ErrorMessage = "Please Enter a Valid Sign-Out Time")]
        public TimeSpan? Sign_Out_Time { get; set; }

        public virtual Program Program { get; set; }

        public virtual Student Student { get; set; }
    }
}