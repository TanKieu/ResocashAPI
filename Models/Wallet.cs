using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ResocashAPI.Models
{
    [Table("Wallet")]
    public partial class Wallet
    {
        [Key]
        [StringLength(255)]
        public string Id { get; set; }
        [Required]
        [StringLength(255)]
        public string CasherId { get; set; }
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }
        [Required]
        [StringLength(3)]
        public string WalletStatus { get; set; }

        [ForeignKey(nameof(CasherId))]
        [InverseProperty("Wallets")]
        public virtual Casher Casher { get; set; }
    }
}
