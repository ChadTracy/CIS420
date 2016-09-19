namespace AHA_Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Event")]
    public partial class Event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Event()
        {
            DonorsAttendences = new HashSet<DonorsAttendence>();
            VolunteerHistories = new HashSet<VolunteerHistory>();
            StudentAttendences = new HashSet<StudentAttendence>();
        }

        [Key]
        [StringLength(12)]
        public string Event_ID { get; set; }

        [Required]
        [StringLength(30)]
        public string Event_Name { get; set; }

        public decimal? Attendence_Cost { get; set; }

        [StringLength(15)]
        public string Event_Type { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Event_Date { get; set; }

        public TimeSpan? Event_Time { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonorsAttendence> DonorsAttendences { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VolunteerHistory> VolunteerHistories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentAttendence> StudentAttendences { get; set; }
    }
}
