namespace AHA_Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonorsAttendence")]
    public partial class DonorsAttendence
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(12)]
        public string Donor_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(12)]
        public string Event_ID { get; set; }

        public TimeSpan? Sign_In_Time { get; set; }

        public TimeSpan? Sign_Out_Time { get; set; }

        public virtual Donor Donor { get; set; }

        public virtual Event Event { get; set; }
    }
}
