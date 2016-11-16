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
        [Key]
        [Column(Order=0)]
        public string Program_ID { get; set; }
        [Required]
        [Key]
        [Column(Order=1)]
        public string AccountID { get; set; }
    }
}