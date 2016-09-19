namespace AHA_Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentAttendence")]
    public partial class StudentAttendence
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(12)]
        public string Student_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(12)]
        public string Event_ID { get; set; }

        public TimeSpan? Sign_in_Time { get; set; }

        public TimeSpan? Sign_Out_Time { get; set; }

        public virtual Event Event { get; set; }

        public virtual Student Student { get; set; }
    }
}
