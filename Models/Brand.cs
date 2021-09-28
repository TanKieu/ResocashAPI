using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ResocashAPI.Models
{
    [Table("Brand")]
    public partial class Brand
    {
        public Brand()
        {
            CashTransactions = new HashSet<CashTransaction>();
            Stores = new HashSet<Store>();
        }

        [Key]
        [StringLength(255)]
        public string Id { get; set; }
        [Required]
        [StringLength(255)]
        public string BrandName { get; set; }
        [Required]
        [StringLength(255)]
        public string BrandAccount { get; set; }
        [Required]
        [StringLength(255)]
        public string BrandPhone { get; set; }
        [Required]
        [StringLength(255)]
        public string BrandAddress { get; set; }

        [InverseProperty(nameof(CashTransaction.Brand))]
        public virtual ICollection<CashTransaction> CashTransactions { get; set; }
        [InverseProperty(nameof(Store.Brand))]
        public virtual ICollection<Store> Stores { get; set; }
    }
}
