using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHA_Web.Models
{
    public partial class StudentFamily
    {

        public string Student_ID { get; set; }


        public string Parent_ID { get; set; }


        public string Type { get; set; }

        public virtual Parent Parent { get; set; }

        public virtual Student Student { get; set; }
    }
}