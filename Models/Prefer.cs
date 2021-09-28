using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ResocashAPI.Models
{
    [Table("Prefer")]
    public partial class Prefer
    {
        [Key]
        [StringLength(255)]
        public string Id { get; set; }
        [Required]
        [StringLength(255)]
        public string BrandId { get; set; }
        [Required]
        [StringLength(255)]
        public string CasherId { get; set; }

        [ForeignKey(nameof(CasherId))]
        [InverseProperty("Prefers")]
        public virtual Casher Casher { get; set; }
    }
}
