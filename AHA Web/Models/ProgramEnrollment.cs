using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AHA_Web.Models
{
    public class ProgramEnrollment
    {
        [Required]
        [Column(Order =0)]
        [Key]
        public string Program_ID { get; set; }

        [Required]
        [Column(Order =1)]
        [Key]
        public string Student_ID { get; set; }

        [Required]
        [Column(Order = 2)]
        [Key]
        public string Enrollment_Period { get; set; }
        public virtual Program Program { get; set; }

        public virtual Student Student { get; set; }
    }
}