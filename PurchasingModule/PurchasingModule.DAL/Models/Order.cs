using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchasingModule.DAL.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        [Required]
        [StringLength(50)]
        public string ShipmentMethod { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime OrderDate { get; set; }
        [Required]
        [StringLength(50)]
        public string Status { get; set; }
        [Required]
        [StringLength(50)]
        public string PaymentMethod { get; set; }
        public int PersonId { get; set; }

        [ForeignKey("CartId")]
        [InverseProperty("Order")]
        public Cart Cart { get; set; }
    }
}
