using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ResocashAPI.Models
{
    [Keyless]
    [Table("WalletTransaction")]
    public partial class WalletTransaction
    {
        [StringLength(255)]
        public string Id { get; set; }
        [Column("WalletID")]
        [StringLength(255)]
        public string WalletId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Datecreate { get; set; }
        [StringLength(10)]
        public string Status { get; set; }
        public int? Amount { get; set; }
        public int? Fee { get; set; }
        [StringLength(500)]
        public string Content { get; set; }
        [StringLength(100)]
        public string ReceiveAccount { get; set; }

        [ForeignKey(nameof(WalletId))]
        public virtual Wallet Wallet { get; set; }
    }
}
