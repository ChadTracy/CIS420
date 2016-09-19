namespace AHA_Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AssignedRole
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(12)]
        public string Staff_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(3)]
        public string Role_Code { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FROM_DATE { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TO_Date { get; set; }

        public virtual AdelanteStaff AdelanteStaff { get; set; }

        public virtual Role Role { get; set; }
    }
}
