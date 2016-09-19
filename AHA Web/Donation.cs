namespace AHA_Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Donation
    {
        [Key]
        [StringLength(8)]
        public string Transaction_ID { get; set; }

        [Required]
        [StringLength(12)]
        public string Donor_ID { get; set; }

        public decimal Donation_Amount { get; set; }

        [StringLength(17)]
        public string Transaction_ID_From_Provider { get; set; }

        public virtual Donor Donor { get; set; }
    }
}
