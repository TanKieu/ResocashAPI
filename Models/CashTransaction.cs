using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ResocashAPI.Models
{
    [Table("CashTransaction")]
    public partial class CashTransaction
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
        [Required]
        [StringLength(255)]
        public string StoreId { get; set; }
        [Column(TypeName = "money")]
        public decimal AmountMoney { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime TransactionTime { get; set; }
        [Required]
        [StringLength(3)]
        public string TransactionStatus { get; set; }

        [ForeignKey(nameof(BrandId))]
        [InverseProperty("CashTransactions")]
        public virtual Brand Brand { get; set; }
    }
}
