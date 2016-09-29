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
        [Required]
        [Key, Column(Order = 0)]
        public string Student_ID { get; set; }

        [Required]
        [Key, Column(Order = 1)]
        public string Parent_ID { get; set; }

        [Required]
        public string Type { get; set; }

        public virtual Parent Parent { get; set; }

        public virtual Student Student { get; set; }
    }
}