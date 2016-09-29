using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace AHA_Web.Models
{
    public class AdelanteStaff
    {
        public AdelanteStaff()
        {
            DonorContacts = new HashSet<DonorContact>();
           
        }

        [Required]
        [Key]
        public string Staff_ID { get; set; }

        [Required]
        public string First_Name { get; set; }

        [Required]
        public string Middle_Initial { get; set; }

        [Required]
        public string Last_Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Zip_Code { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }


        public DateTime? Hire_Date { get; set; }


      


        public virtual ICollection<DonorContact> DonorContacts { get; set; }


        
    }
}