using BitirmeProjesi.Core.Entity;
using System;

namespace BitirmeProjesi.Model.Entities
{
    public class ProductComment : CoreEntity
    {
        public string title { get; set; }
        public string content { get; set; }
        public bool status { get; set; }
        public int rank { get; set; }
        public bool isAnonymous { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public Member memberId { get; set; }
        public Product productId { get; set; }
    }
}
