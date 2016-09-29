using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AHA_Web.Models
{
    public partial class BoardMember
    {

        [Required]
        [Key]
        public string BM_ID { get; set; }

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
        public string Zip { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }


        public string Affiliated_Organization { get; set; }


    }
}