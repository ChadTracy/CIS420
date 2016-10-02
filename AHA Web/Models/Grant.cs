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
        
        [Key]
        [Required]
        [Display(Name = "Grant ID")]
        [MinLength(12),MaxLength(12)]
        public string Grant_ID { get; set; }

        [ForeignKey("Grantor")]
        [Required]
        [Display(Name = "Grantor ID")]
        [MinLength(5),MaxLength(5)]
        public string Grantor_ID { get; set; }

        [Required]
        [Display(Name = "Grant Name")]
        [MaxLength(40)] 
        public string Grant_Name { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Please Enter a Valid Date")]
        public DateTime? Grant_Due_Date { get; set; }

        [DataType(DataType.Currency,ErrorMessage ="Please Enter a Valid Amount")]
        public decimal? Grant_Amount { get; set; }


        public string Grant_Type { get; set; }


        public string Grant_status { get; set; }


        public string Author { get; set; }

        public virtual Grantor Grantor { get; set; }
    }
}