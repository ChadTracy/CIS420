namespace AHA_Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Grantor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Grantor()
        {
            Grants = new HashSet<Grant>();
        }

        [Key]
        [StringLength(6)]
        public string Grantor_ID { get; set; }

        [Required]
        [StringLength(35)]
        public string Organization { get; set; }

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
        public virtual ICollection<Grant> Grants { get; set; }
    }
}
