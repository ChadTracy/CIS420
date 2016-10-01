using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHA_Web.Models
{
    public partial class School
    {

        public School()
        {
            SchoolAttendeds = new HashSet<SchoolAttended>();
        }


        public string School_ID { get; set; }


        public string School_Name { get; set; }


        public string Address { get; set; }


        public string City { get; set; }


        public string State { get; set; }


        public string Zip_Code { get; set; }


        public string Phone { get; set; }


        public virtual ICollection<SchoolAttended> SchoolAttendeds { get; set; }
    }
}