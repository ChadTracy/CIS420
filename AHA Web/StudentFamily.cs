namespace AHA_Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentFamily")]
    public partial class StudentFamily
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(12)]
        public string Student_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(12)]
        public string Parent_ID { get; set; }

        [Required]
        [StringLength(8)]
        public string Type { get; set; }

        public virtual Parent Parent { get; set; }

        public virtual Student Student { get; set; }
    }
}
