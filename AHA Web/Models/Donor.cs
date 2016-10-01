using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHA_Web.Models
{
    public partial class Donor
    {

        public Donor()
        {

            Donations = new HashSet<Donation>();
            DonorContacts = new HashSet<DonorContact>();
            DonorsAttendences = new HashSet<DonorsAttendence>();
        }


        public string Donor_ID { get; set; }


        public string First_Name { get; set; }


        public string Middle_Initial { get; set; }


        public string Last_Name { get; set; }


        public string Address { get; set; }


        public string City { get; set; }


        public string State { get; set; }


        public string Zip_Code { get; set; }


        public string Email { get; set; }


        public string Phone { get; set; }




        public virtual ICollection<Donation> Donations { get; set; }

        public virtual ICollection<DonorContact> DonorContacts { get; set; }

        public virtual ICollection<DonorsAttendence> DonorsAttendences { get; set; }
    }
}