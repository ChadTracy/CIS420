using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AHA_Web.Models
{
    public partial class Student
    {

        public Student()
        {

            StudentAttendences = new HashSet<StudentAttendence>();
            StudentFamilies = new HashSet<StudentFamily>();
        }

        [Key]
        [Required]
        [Display(Name = "Student ID")]
        [MinLength(12),MaxLength(12)]
        public string Student_ID { get; set; }

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
        public string Zip_Code { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Not a Valid Email Address")]
        public string Email { get; set; }

        
        public string Gender { get; set; }

        [Required]
        public bool Ambassador { get; set; }

        public string School { get; set; }

        public virtual ICollection<StudentAttendence> StudentAttendences { get; set; }

        public virtual ICollection<ProgramEnrollment> ProgramEnrollments { get; set; }

        public virtual ICollection<StudentFamily> StudentFamilies { get; set; }
    }
}