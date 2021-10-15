using BitirmeProjesi.Core.Entity;
using System;
namespace BitirmeProjesi.Model.Entities
{
    public class OrderUserNote : CoreEntity
    {
        public string userEmail { get; set; }
        public string userFirstname { get; set; }
        public string userSurname { get; set; }
        public string note { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public Order orderId { get; set; }
    }
}
