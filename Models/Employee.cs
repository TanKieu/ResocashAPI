using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ResocashAPI.Models
{
    [Table("Employee")]
    public partial class Employee
    {
        public Employee()
        {
            CashingRequests = new HashSet<CashingRequest>();
        }

        [Key]
        [StringLength(255)]
        public string Id { get; set; }
        [StringLength(255)]
        public string StoreId { get; set; }
        [StringLength(50)]
        public string EmployeeSex { get; set; }
        [StringLength(50)]
        public string EmployeePhone { get; set; }

        [ForeignKey(nameof(StoreId))]
        [InverseProperty("Employees")]
        public virtual Store Store { get; set; }
        [InverseProperty(nameof(CashingRequest.Employee))]
        public virtual ICollection<CashingRequest> CashingRequests { get; set; }
    }
}
