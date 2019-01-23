using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchasingModule.DAL.Models
{
    public partial class ProductCart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }

        [ForeignKey("CartId")]
        [InverseProperty("ProductCart")]
        public Cart Cart { get; set; }
    }
}
