using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchasingModule.DAL.Models
{
    public partial class Cart
    {
        public Cart()
        {
            Order = new HashSet<Order>();
            ProductCart = new HashSet<ProductCart>();
        }

        public int Id { get; set; }
        public int PersonId { get; set; }
        public double? TotalPrice { get; set; }
        public bool OrderSent { get; set; }

        [InverseProperty("Cart")]
        public ICollection<Order> Order { get; set; }
        [InverseProperty("Cart")]
        public ICollection<ProductCart> ProductCart { get; set; }
    }
}
