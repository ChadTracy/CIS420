using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AHA_Web.Models
{
    public partial class Donor
    {

        public Donor()
        {
            DonorContacts = new HashSet<DonorContact>();
            
        }

        [Required]
        [Key]
        [Display(Name = "Donor ID")]
        [MaxLength(9), MinLength(9)]
        public string Donor_ID { get; set; }

        [Required]
        [Display(Name ="First Name")]
        [MaxLength(20)]
        public string First_Name { get; set; }

       
      
        [Display(Name = "Middle Initial")]
        [MaxLength(3)]
        public string Middle_Initial { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(35)]
        public string Last_Name { get; set; }

        [Display(Name = "Address")]
        [MaxLength(40)]
        public string Address { get; set; }

        [Display(Name = "City")]
        [MaxLength(15)]
        public string City { get; set; }

        [Display(Name = "State")]
        [MaxLength(2)]
        public string State { get; set; }

        [Display(Name = "Zip Code")]
        [DataType(DataType.PostalCode, ErrorMessage = "Not a Valid Postal Code")]
        public string Zip_Code { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Not a valid email address")]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber, ErrorMessage= "Please Enter a Valid Phone Number")]
        public string Phone { get; set; }

        public virtual ICollection<DonorContact> DonorContacts { get; set; }
    }
}