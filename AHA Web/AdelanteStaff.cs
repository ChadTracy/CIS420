namespace AHA_Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdelanteStaff")]
    public partial class AdelanteStaff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AdelanteStaff()
        {
            Account_Link = new HashSet<Account_Link>();
            DonorContacts = new HashSet<DonorContact>();
            AssignedRoles = new HashSet<AssignedRole>();
        }

        [Key]
        [StringLength(12)]
        public string Staff_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string First_Name { get; set; }

        [Required]
        [StringLength(2)]
        public string Middle_Initial { get; set; }

        [Required]
        [StringLength(35)]
        public string Last_Name { get; set; }

        [Required]
        [StringLength(40)]
        public string Address { get; set; }

        [Required]
        [StringLength(15)]
        public string City { get; set; }

        [Required]
        [StringLength(2)]
        public string State { get; set; }

        [Required]
        [StringLength(9)]
        public string Zip_Code { get; set; }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        [StringLength(10)]
        public string Phone { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Hire_Date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Account_Link> Account_Link { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonorContact> DonorContacts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssignedRole> AssignedRoles { get; set; }
    }
}
