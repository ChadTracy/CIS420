using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHA_Web.Models
{
    public partial class Donation
    {

        public string Transaction_ID { get; set; }


        public string Donor_ID { get; set; }

        public decimal Donation_Amount { get; set; }


        public string Transaction_ID_From_Provider { get; set; }

        public virtual Donor Donor { get; set; }
    }
}