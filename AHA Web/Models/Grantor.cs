using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AHA_Web.Models
{
    public partial class Grantor
    {

        public Grantor()
        {
            Grants = new HashSet<Grant>();
        }

        [Key]
        [Required] 
        [MaxLength(5),MinLength(5)]
        [Display(Name = "Grantor ID")]
        public string Grantor_ID { get; set; }

        [Required]
        [Display(Name = "Granting Organization")]
        [MaxLength(45)]
        public string Organization { get; set; }

        [MaxLength(40)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [MaxLength(15)]
        [Display(Name = "City")]
        public string City { get; set; }

        [MaxLength(2)]
        [Display(Name = "State")]
        public string State { get; set; }

        [DataType(DataType.PostalCode, ErrorMessage = "Please Enter a Valid Postal Code")]
        [Display(Name = "Zip Code")]
        public string Zip_Code { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage ="Not a Valid Email Address")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage ="Please enter a Valid Phone Number")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }


        public virtual ICollection<Grant> Grants { get; set; }
    }
}