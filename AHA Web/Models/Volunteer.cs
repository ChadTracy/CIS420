using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AHA_Web.Models
{
    public partial class Volunteer
    {

        public Volunteer()
        {

            VolunteerHistories = new HashSet<VolunteerHistory>();
        }

        [Key]
        [Required]
        [Display(Name = "Volunteer ID")]
        [MaxLength(11),MinLength(11)]
        public string Volunteer_ID { get; set; }

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
        [DataType(DataType.PostalCode, ErrorMessage = "Please Enter a Valid Postal Code")]
        [Display(Name = "Zip Code")]
        public string Zip_Code { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Not a Valid Email Address")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please Enter a Valid Phone Number")]   
        public string Phone { get; set; }


        public virtual ICollection<VolunteerHistory> VolunteerHistories { get; set; }
    }
}