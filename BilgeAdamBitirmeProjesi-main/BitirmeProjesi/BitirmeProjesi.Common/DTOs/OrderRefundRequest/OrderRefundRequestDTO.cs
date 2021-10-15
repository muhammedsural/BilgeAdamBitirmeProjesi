using BitirmeProjesi.Common.DTOs.Base;
using System;
namespace BitirmeProjesi.Common.DTOs.OrderRefundRequest
{
    public class OrderRefundRequestDTO : BaseDto
    {
        public string code { get; set; }
        public string status { get; set; }
        public decimal fee { get; set; }
        public string cancellationReason { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public int memberId { get; set; }
        public int orderId { get; set; }
    }
}
