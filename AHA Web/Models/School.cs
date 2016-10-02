using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AHA_Web.Models
{
    public partial class School
    {

        public School()
        {
            SchoolAttendeds = new HashSet<SchoolAttended>();
        }

        [Key]
        [Required]
        [Display(Name = "School ID")]
        [MinLength(8),MaxLength(8)]
        public string School_ID { get; set; }

        [Required]
        [Display(Name = "School Name")]
        [MaxLength(40)]
        public string School_Name { get; set; }

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
        [MaxLength(2),MinLength(2)]
        public string State { get; set; }

        [Required]
        [DataType(DataType.PostalCode,ErrorMessage = "Please Enter a Valid Postal Code")]
        public string Zip_Code { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber,ErrorMessage ="Please Enter a Valid Phone Number")]
        public string Phone { get; set; }


        public virtual ICollection<SchoolAttended> SchoolAttendeds { get; set; }
    }
}