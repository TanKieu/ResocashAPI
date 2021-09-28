using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ResocashAPI.Models
{
    [Table("Area")]
    public partial class Area
    {
        public Area()
        {
            Locations = new HashSet<Location>();
            Stores = new HashSet<Store>();
        }

        [Key]
        [StringLength(255)]
        public string Id { get; set; }
        [Required]
        [StringLength(500)]
        public string AreaName { get; set; }
        [Required]
        [StringLength(700)]
        public string AreaLocation { get; set; }

        [InverseProperty(nameof(Location.Area))]
        public virtual ICollection<Location> Locations { get; set; }
        [InverseProperty(nameof(Store.Area))]
        public virtual ICollection<Store> Stores { get; set; }
    }
}
