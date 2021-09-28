using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ResocashAPI.Models
{
    [Table("Location")]
    public partial class Location
    {
        [Key]
        [StringLength(255)]
        public string Id { get; set; }
        [Required]
        [StringLength(255)]
        public string AreaId { get; set; }
        [Required]
        [StringLength(255)]
        public string CasherId { get; set; }

        [ForeignKey(nameof(AreaId))]
        [InverseProperty("Locations")]
        public virtual Area Area { get; set; }
        [ForeignKey(nameof(CasherId))]
        [InverseProperty("Locations")]
        public virtual Casher Casher { get; set; }
    }
}
