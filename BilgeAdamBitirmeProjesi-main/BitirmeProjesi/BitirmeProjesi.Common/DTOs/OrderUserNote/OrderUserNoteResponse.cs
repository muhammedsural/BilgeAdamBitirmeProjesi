using BitirmeProjesi.Common.DTOs.Base;
using System;
namespace BitirmeProjesi.Common.DTOs.OrderUserNote
{
    public class OrderUserNoteResponse : BaseDto
    {
        public string userEmail { get; set; }
        public string userFirstname { get; set; }
        public string userSurname { get; set; }
        public string note { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public int orderId { get; set; }
    }
}
