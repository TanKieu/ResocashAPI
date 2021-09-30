using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;



namespace ResocashAPI.Models
{
    [Table("User")]
    public partial class User
    {

        [Key]
        [StringLength(255)]
        public string UserID { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(255)]
        public string Password { get; set; }
        [StringLength(255)]
        public string Fullname { get; set; }
        [StringLength(20)]
        public string role { get; set; }
        [StringLength(15)]
        public string Phone { get; set; }
        public bool UserStatus { get; set; }

    }

}

    
