using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AHA_Web.Models
{
    public partial class AdelanteStaff
    {
        public AdelanteStaff()
        {
            DonorContacts = new HashSet<DonorContact>();
           
        }
      
        [Required]
        [Key]
        [Display(Name = "Staff ID")]
        [MaxLength(6), MinLength(6)]
        public string Staff_ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [MaxLength(20)]
        public string First_Name { get; set; }

        [Required]
        [Display(Name = "Middle Initial")]
        [MaxLength(3)]
        public string Middle_Initial { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(35)]
        public string Last_Name { get; set; }

        [Required]
        [Display(Name = "Address")]
        [MaxLength(40)]
        public string Address { get; set; }

        [Required]
        [Display(Name = "City")]
        [MaxLength(15)]
        public string City { get; set; }

        [Required]
        [Display(Name = "State")]
        [MaxLength(2)]
        public string State { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        [MaxLength(9), MinLength(5)]
        [DataType(DataType.PostalCode, ErrorMessage = "Please Enter a Valid Postal Code")]
        public string Zip_Code { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Not a Valid Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please Enter a Valid Phone Number")]
        [MaxLength(10)]
        public string Phone { get; set; }

        [Display(Name = "Alternate Phone Number")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please Enter a Valid Phone Number")]
        [MaxLength(10)]
        public string Alt_Phone { get; set; }

        public DateTime? Hire_Date { get; set; }


      


        public virtual ICollection<DonorContact> DonorContacts { get; set; }


        
    }
}