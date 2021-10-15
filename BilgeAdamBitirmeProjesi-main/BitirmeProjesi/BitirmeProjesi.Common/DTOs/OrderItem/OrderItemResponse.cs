using BitirmeProjesi.Common.DTOs.Base;
namespace BitirmeProjesi.Common.DTOs.OrderItem
{
    public class OrderItemResponse : BaseDto
    {
        public string productName { get; set; }
        public decimal productPrice { get; set; }
        public decimal productQuantity { get; set; }
        public int productTax { get; set; }
        public string productStockTypeLabel { get; set; }
        public int orderId { get; set; }
        public int productId { get; set; }
    }
}
