using BitirmeProjesi.Core.Entity;
using System;
namespace BitirmeProjesi.Model.Entities
{
    public class OrderRefundRequestItem : CoreEntity
    {
        public decimal amount { get; set; }
        public string reason { get; set; }
        public string details { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public OrderItem orderItemId { get; set; }
        public OrderRefundRequest orderRefundRequestId { get; set; }
    }
}
