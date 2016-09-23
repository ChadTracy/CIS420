using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHA_Web.Models
{
    public partial class Grant
    {

        public string Grant_ID { get; set; }


        public string Grantor_ID { get; set; }

        public string Grant_Name { get; set; }

        public DateTime? Grant_Due_Date { get; set; }

        public decimal? Grant_Amount { get; set; }


        public string Grant_Type { get; set; }


        public string Grant_status { get; set; }


        public string Author { get; set; }

        public virtual Grantor Grantor { get; set; }
    }
}