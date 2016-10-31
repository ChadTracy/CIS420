using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AHA_Web.Models
{
    public class ProgramEnrollment
    {
        [Required]
        [Key]
        public string Enrollment_Number { get; set; }
        public string Program_ID { get; set; }
        public string EventID { get; set; }
        public string StudentEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
        
        public bool Attended { get; set; }
     
        public virtual Program Program { get; set; }

        

     
    }
}