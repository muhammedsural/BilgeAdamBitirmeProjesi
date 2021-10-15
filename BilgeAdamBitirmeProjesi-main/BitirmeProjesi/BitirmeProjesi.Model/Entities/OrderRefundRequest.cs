using BitirmeProjesi.Core.Entity;
using System;
namespace BitirmeProjesi.Model.Entities
{
    public class OrderRefundRequest : CoreEntity
    {
        public string code { get; set; }
        public string status { get; set; }
        public decimal fee { get; set; }
        public string cancellationReason { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public Member memberId { get; set; }
        public Order orderId { get; set; }
    }
}
