using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ResocashAPI.Models
{
    [Table("Casher")]
    public partial class Casher
    {
        public Casher()
        {
            Bookings = new HashSet<Booking>();
            CashingRequests = new HashSet<CashingRequest>();
            Locations = new HashSet<Location>();
            Prefers = new HashSet<Prefer>();
            Wallets = new HashSet<Wallet>();
        }

        [Key]
        [StringLength(255)]
        public string Id { get; set; }
        [Required]
        [StringLength(500)]
        public string CasherName { get; set; }
        [StringLength(10)]
        public string Gender { get; set; }
        [Column(TypeName = "date")]
        public DateTime DayOfBirth { get; set; }
        [Required]
        [StringLength(12)]
        public string IdentityNumber { get; set; }
        [Required]
        [Column("WalletID")]
        [StringLength(255)]
        public string WalletId { get; set; }

        [InverseProperty(nameof(Booking.Casher))]
        public virtual ICollection<Booking> Bookings { get; set; }
        [InverseProperty(nameof(CashingRequest.Casher))]
        public virtual ICollection<CashingRequest> CashingRequests { get; set; }
        [InverseProperty(nameof(Location.Casher))]
        public virtual ICollection<Location> Locations { get; set; }
        [InverseProperty(nameof(Prefer.Casher))]
        public virtual ICollection<Prefer> Prefers { get; set; }
        [InverseProperty(nameof(Wallet.Casher))]
        public virtual ICollection<Wallet> Wallets { get; set; }
    }
}
