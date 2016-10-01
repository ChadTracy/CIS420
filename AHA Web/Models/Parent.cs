using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHA_Web.Models
{
    public partial class Parent
    {

        public Parent()
        {

            StudentFamilies = new HashSet<StudentFamily>();
        }


        public string Parent_ID { get; set; }


        public string First_Name { get; set; }


        public string Middle_Initial { get; set; }


        public string Last_Name { get; set; }

        public string Address { get; set; }


        public string City { get; set; }


        public string State { get; set; }


        public string Zip_Code { get; set; }


        public string Email { get; set; }


        public string Phone { get; set; }



        public virtual ICollection<StudentFamily> StudentFamilies { get; set; }
    }
}