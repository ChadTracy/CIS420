using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AHA_Web.Models
{
    public partial class BoardMember
    {

        [Required]
        [Key]
        [Display(Name = "Board Member ID")]
        [MaxLength(7), MinLength(7)]
        public string BM_ID { get; set; }

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
        [MaxLength(30)]
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
        [DataType(DataType.PostalCode, ErrorMessage = "Not a Valid Postal Code")]
        public string Zip { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please Enter a Valid Phone Number")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Not a valid email address")]
        public string Email { get; set; }

        [Display(Name = "Affiliated Organization")]
        [MaxLength(45)]
        public string Affiliated_Organization { get; set; }


    }
}