using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHA_Web.Models
{
    public class ProgramEnrollment
    {
        public string Program_ID { get; set; }

        public string Student_ID { get; set; }

        public virtual Program Program { get; set; }

        public virtual Student Student { get; set; }
    }
}