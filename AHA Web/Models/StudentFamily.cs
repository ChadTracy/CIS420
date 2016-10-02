using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AHA_Web.Models
{
    public partial class StudentFamily
    {

        [Key]
        [Display(Name ="Student ID")]
        [MinLength(12),MaxLength(12)]
        [Column(Order = 0)]
        public string Student_ID { get; set; }

        [Key]
        [Display(Name ="Parent ID")]
        [MaxLength(10),MinLength(10)]
        [Column(Order = 1)]     
        public string Parent_ID { get; set; }

        [Required]
        [MaxLength(10)]
        public string Type { get; set; }

        public virtual Parent Parent { get; set; }

        public virtual Student Student { get; set; }
    }
}