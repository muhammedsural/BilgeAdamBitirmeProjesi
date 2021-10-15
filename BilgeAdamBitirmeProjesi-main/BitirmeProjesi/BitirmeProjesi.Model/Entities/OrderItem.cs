using BitirmeProjesi.Core.Entity;
using System.Collections.Generic;

namespace BitirmeProjesi.Model.Entities
{
    public class OrderItem : CoreEntity
    {
        public string productName { get; set; }
        public decimal productPrice { get; set; }
        public decimal productQuantity { get; set; }
        public int productTax { get; set; }
        public string productStockTypeLabel { get; set; }
        public int orderId { get; set; }
        public Order Order { get; set; }
        public int productId { get; set; }
        public Product Product { get; set; }
    }
}