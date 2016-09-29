using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AHA_Web.Models
{
    public partial class School
    {

        public School()
        {
            SchoolAttendeds = new HashSet<SchoolAttended>();
        }

        [Required]
        [Key]
        public string School_ID { get; set; }

        [Required]
        public string School_Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Zip_Code { get; set; }

        [Required]
        public string Phone { get; set; }


        public virtual ICollection<SchoolAttended> SchoolAttendeds { get; set; }
    }
}