namespace AHA_Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SchoolAttended")]
    public partial class SchoolAttended
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(12)]
        public string Student_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(7)]
        public string School_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FROM_DATE { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TO_Date { get; set; }

        public virtual School School { get; set; }

        public virtual Student Student { get; set; }
    }
}
