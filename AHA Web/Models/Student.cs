using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHA_Web.Models
{
    public partial class Student
    {

        public Student()
        {

            SchoolAttendeds = new HashSet<SchoolAttended>();
            StudentAttendences = new HashSet<StudentAttendence>();
            StudentFamilies = new HashSet<StudentFamily>();
        }


        public string Student_ID { get; set; }


        public string First_Name { get; set; }


        public string Middle_Initial { get; set; }


        public string Last_Name { get; set; }


        public string Address { get; set; }


        public string City { get; set; }


        public string State { get; set; }

        public string Zip_Code { get; set; }


        public string Email { get; set; }


        public string Gender { get; set; }

        public bool Ambassador { get; set; }



        public virtual ICollection<SchoolAttended> SchoolAttendeds { get; set; }


        public virtual ICollection<StudentAttendence> StudentAttendences { get; set; }


        public virtual ICollection<StudentFamily> StudentFamilies { get; set; }
    }
}