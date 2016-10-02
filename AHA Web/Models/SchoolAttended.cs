using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AHA_Web.Models
{
    public partial class SchoolAttended
    {

        [Key]
        [Required]
        [Display(Name = "Student ID")]
        [MaxLength(12),MinLength(12)]
        [Column(Order = 0)]
        public string Student_ID { get; set; }

        [Key]
        [Required]
        [Display(Name = "School ID")]
        [MaxLength(8),MinLength(8)]
        [Column(Order = 1)]
        public string School_ID { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date, ErrorMessage = "Please Provide a Valid Start Date")]
        public DateTime? FROM_DATE { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date, ErrorMessage = "Please Provide a Valid Ending Date")]
        public DateTime? TO_Date { get; set; }

        public virtual School School { get; set; }

        public virtual Student Student { get; set; }
    }
}