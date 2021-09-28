using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ResocashAPI.Models
{
    [Table("CashingRequest")]
    public partial class CashingRequest
    {
        [Key]
        [StringLength(255)]
        public string Id { get; set; }
        [Column(TypeName = "date")]
        public DateTime? LocalDateTime { get; set; }
        [StringLength(255)]
        public string StoreId { get; set; }
        [StringLength(255)]
        public string EmployeeId { get; set; }
        [StringLength(255)]
        public string CasherId { get; set; }

        [ForeignKey(nameof(CasherId))]
        [InverseProperty("CashingRequests")]
        public virtual Casher Casher { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty("CashingRequests")]
        public virtual Employee Employee { get; set; }
        [ForeignKey(nameof(StoreId))]
        [InverseProperty("CashingRequests")]
        public virtual Store Store { get; set; }
    }
}
