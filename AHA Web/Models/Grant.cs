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
        public int Grant_ID { get; set; }
        
        [Required]
        [Display(Name = "Grantor ID")]
        public string Grantor_ID { get; set; }

        [Required]
        [Display(Name = "Grant Name")]
        [MaxLength(100)] 
        public string Grant_Name { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Please Enter a Valid Date")]
        public DateTime? Grant_Due_Date { get; set; }

        [DataType(DataType.Currency,ErrorMessage ="Please Enter a Valid Amount")]
        public decimal? Grant_Amount { get; set; }


        public string Grant_Type { get; set; }


        public string Grant_status { get; set; }


        public string Author { get; set; }

        public string File_Link { get; set; }

        public virtual Grantor Grantor { get; set; }
    }
}