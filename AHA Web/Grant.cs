namespace AHA_Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Grant
    {
        [Key]
        [StringLength(12)]
        public string Grant_ID { get; set; }

        [Required]
        [StringLength(6)]
        public string Grantor_ID { get; set; }

        [Required]
        [StringLength(3)]
        public string Grant_Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Grant_Due_Date { get; set; }

        public decimal? Grant_Amount { get; set; }

        [StringLength(15)]
        public string Grant_Type { get; set; }

        [StringLength(11)]
        public string Grant_status { get; set; }

        [StringLength(12)]
        public string Author { get; set; }

        public virtual Grantor Grantor { get; set; }
    }
}
