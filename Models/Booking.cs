using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ResocashAPI.Models
{
    [Table("Booking")]
    public partial class Booking
    {
        [Key]
        [StringLength(255)]
        public string Id { get; set; }
        [Required]
        [StringLength(255)]
        public string CasherId { get; set; }
        [Required]
        [StringLength(255)]
        public string StoreId { get; set; }

        [ForeignKey(nameof(CasherId))]
        [InverseProperty("Bookings")]
        public virtual Casher Casher { get; set; }
        [ForeignKey(nameof(StoreId))]
        [InverseProperty("Bookings")]
        public virtual Store Store { get; set; }
    }
}
