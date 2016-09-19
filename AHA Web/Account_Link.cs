namespace AHA_Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Account_Link
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string Account_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(12)]
        public string UserID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date_Created { get; set; }

        [StringLength(12)]
        public string Approved_By { get; set; }

        [StringLength(15)]
        public string Account_Type { get; set; }

        public virtual Parent Parent { get; set; }

        public virtual Student Student { get; set; }

        public virtual User_Acct User_Acct { get; set; }

        public virtual BoardMember BoardMember { get; set; }

        public virtual Donor Donor { get; set; }

        public virtual AdelanteStaff AdelanteStaff { get; set; }

        public virtual Volunteer Volunteer { get; set; }
    }
}
