using BitirmeProjesi.Core.Entity;
using System;
using System.Collections.Generic;

namespace BitirmeProjesi.Model.Entities
{
    public class Cart : CoreEntity
    {
        public Cart()
        {
            CartItem = new List<CartItem>();
        }

        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }

        public Member Member { get; set; }
        public int MemberId { get; set; }
        public int ShopTokensId { get; set; }
        public List<CartItem> CartItem { get; set; }
    }
}