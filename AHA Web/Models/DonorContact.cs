using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHA_Web.Models
{
    public partial class DonorContact
    {

        public string Donor_ID { get; set; }


        public string Staff_ID { get; set; }


        public DateTime Date { get; set; }


        public string Method_Of_Contact { get; set; }

        public virtual AdelanteStaff AdelanteStaff { get; set; }

        public virtual Donor Donor { get; set; }
    }
}