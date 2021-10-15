using BitirmeProjesi.Common.DTOs.Base;
using System;
namespace BitirmeProjesi.Common.DTOs.OrderRefundRequestItem
{
    public class OrderRefundRequestItemRequest : BaseDto
    {
        public decimal amount { get; set; }
        public string reason { get; set; }
        public string details { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public int orderItemId { get; set; }
        public int orderRefundRequestId { get; set; }
    }
}
