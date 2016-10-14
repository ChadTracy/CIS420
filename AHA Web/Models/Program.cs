using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 

namespace AHA_Web.Models
{
    public class Program
    {
        
        public string Program_ID { get; set; }

        public string Program_Name { get; set; }

        public string Program_Location { get; set; }

        public string Description { get; set; }

        public virtual ICollection<ProgramEnrollment> ProgramEnrollments { get; set; }
    }
}