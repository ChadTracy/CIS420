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
        [Required]
        [Key, Column(Order = 0)]
        public string Student_ID { get; set; }

        [Required]
        [Key,Column(Order = 1)]
        public string School_ID { get; set; }

        public DateTime? FROM_DATE { get; set; }


        public DateTime? TO_Date { get; set; }

        public virtual School School { get; set; }

        public virtual Student Student { get; set; }
    }
}