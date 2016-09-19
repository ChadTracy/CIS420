namespace AHA_Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Donor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Donor()
        {
            Account_Link = new HashSet<Account_Link>();
            Donations = new HashSet<Donation>();
            DonorContacts = new HashSet<DonorContact>();
            DonorsAttendences = new HashSet<DonorsAttendence>();
        }

        [Key]
        [StringLength(12)]
        public string Donor_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string First_Name { get; set; }

        [Required]
        [StringLength(2)]
        public string Middle_Initial { get; set; }

        [Required]
        [StringLength(35)]
        public string Last_Name { get; set; }

        [StringLength(40)]
        public string Address { get; set; }

        [StringLength(15)]
        public string City { get; set; }

        [StringLength(2)]
        public string State { get; set; }

        [StringLength(9)]
        public string Zip_Code { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Account_Link> Account_Link { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Donation> Donations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonorContact> DonorContacts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonorsAttendence> DonorsAttendences { get; set; }
    }
}
