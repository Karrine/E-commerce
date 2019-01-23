using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseModule.DAL.Models
{
    public partial class ProductInventory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        [Required]
        [StringLength(40)]
        public string DepositName { get; set; }
        [Required]
        [StringLength(10)]
        public string Shelf { get; set; }
        [Required]
        [StringLength(10)]
        public string Bin { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("ProductId")]
        [InverseProperty("ProductInventory")]
        public Product Product { get; set; }
    }
}
