using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseModule.DAL.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductInventory = new HashSet<ProductInventory>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(30)]
        public string Description { get; set; }
        public double Price { get; set; }
        [Required]
        [StringLength(20)]
        public string Category { get; set; }
        [StringLength(10)]
        public string Weight { get; set; }
        [StringLength(20)]
        public string Dimensions { get; set; }
        [StringLength(30)]
        public string Vendor { get; set; }

        [InverseProperty("Product")]
        public ICollection<ProductInventory> ProductInventory { get; set; }
    }
}
