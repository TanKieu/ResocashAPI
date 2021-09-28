using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ResocashAPI.Models
{
    [Table("Store")]
    public partial class Store
    {
        public Store()
        {
            Bookings = new HashSet<Booking>();
            CashingRequests = new HashSet<CashingRequest>();
            Employees = new HashSet<Employee>();
        }

        [Key]
        [StringLength(255)]
        public string Id { get; set; }
        [StringLength(255)]
        public string BrandId { get; set; }
        [StringLength(400)]
        public string StoreAddress { get; set; }
        [Required]
        [StringLength(12)]
        public string StorePhone { get; set; }
        public TimeSpan? OpenTime { get; set; }
        public TimeSpan? CloseTime { get; set; }
        public bool StoreStatus { get; set; }
        [StringLength(255)]
        public string AreaId { get; set; }

        [ForeignKey(nameof(AreaId))]
        [InverseProperty("Stores")]
        public virtual Area Area { get; set; }
        [ForeignKey(nameof(BrandId))]
        [InverseProperty("Stores")]
        public virtual Brand Brand { get; set; }
        [InverseProperty(nameof(Booking.Store))]
        public virtual ICollection<Booking> Bookings { get; set; }
        [InverseProperty(nameof(CashingRequest.Store))]
        public virtual ICollection<CashingRequest> CashingRequests { get; set; }
        [InverseProperty(nameof(Employee.Store))]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
