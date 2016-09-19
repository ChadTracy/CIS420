namespace AHA_Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VolunteerHistory")]
    public partial class VolunteerHistory
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(12)]
        public string Volunteer_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(12)]
        public string Event_ID { get; set; }

        public int Hours_Worked { get; set; }

        public virtual Event Event { get; set; }

        public virtual Volunteer Volunteer { get; set; }
    }
}
