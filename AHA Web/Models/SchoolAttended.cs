using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHA_Web.Models
{
    public partial class SchoolAttended
    {

        public string Student_ID { get; set; }


        public string School_ID { get; set; }


        public DateTime? FROM_DATE { get; set; }


        public DateTime? TO_Date { get; set; }

        public virtual School School { get; set; }

        public virtual Student Student { get; set; }
    }
}