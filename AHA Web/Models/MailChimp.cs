using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AHA_Web.Models
{
    public partial class MailChimp
    {
       [Required]
       [Key]
       [Display(Name ="List ID")]
       public string ListID { get; set; }

        [Required]
        [Display(Name = "List Name")]
        public string ListName { get; set; }
    }
}