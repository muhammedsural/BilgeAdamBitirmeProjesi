using BitirmeProjesi.Core.Entity;
using System;

namespace BitirmeProjesi.Model.Entities
{
    public class CartItem : CoreEntity
    {
        public int? parentProductId { get; set; }
        public decimal quantity { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        
        public int CartId { get; set; }
        public Cart Cart { get; set; }
       
        public int productId { get; set; }
        public Product product { get; set; }
    }
}