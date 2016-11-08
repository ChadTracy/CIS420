using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AHA_Web.Models
{
    public class Attendance
    {
        [Key]
        [Column(Order = 0)]
        public string EventID { get; set; }

        [Key]
        [Column(Order = 1)]
        public string Email { get; set; }

        public DateTime? SignIn {get; set;}
        public DateTime? SignOut {get; set;}
    }
}