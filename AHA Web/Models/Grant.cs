using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AHA_Web.Models
{
    public partial class Grant
    {
        [Required]
        [Display(Name ="Grant ID")]
        [Key, Column(Order = 0)]
        public string Grant_ID { get; set; }

        [Required]
        [Display(Name ="Grantor ID")]
        [Key, Column(Order = 1)]
        public string Grantor_ID { get; set; }

        [Required]
        [Display(Name = "Grant Name")]
        public string Grant_Name { get; set; }

        [Required]
        [Display(Name = "Due Date")]
        public DateTime? Grant_Due_Date { get; set; }

        [Required]
        [Display(Name = "Grant Amount")]
        public decimal? Grant_Amount { get; set; }

        [Required]
        [Display(Name = "Type of Grant")]
        public string Grant_Type { get; set; }

        [Display(Name = "Status")]
        public string Grant_status { get; set; }


        public string Author { get; set; }

        public virtual Grantor Grantor { get; set; }
    }
}