using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHA_Web.Models
{
    public partial class Grantor
    {

        public Grantor()
        {
            Grants = new HashSet<Grant>();
        }


        public string Grantor_ID { get; set; }


        public string Organization { get; set; }


        public string Address { get; set; }


        public string City { get; set; }


        public string State { get; set; }


        public string Zip_Code { get; set; }


        public string Email { get; set; }


        public string Phone { get; set; }


        public virtual ICollection<Grant> Grants { get; set; }
    }
}