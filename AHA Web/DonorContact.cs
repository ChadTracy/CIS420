namespace AHA_Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonorContact")]
    public partial class DonorContact
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(12)]
        public string Donor_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(12)]
        public string Staff_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [StringLength(20)]
        public string Method_Of_Contact { get; set; }

        public virtual AdelanteStaff AdelanteStaff { get; set; }

        public virtual Donor Donor { get; set; }
    }
}
