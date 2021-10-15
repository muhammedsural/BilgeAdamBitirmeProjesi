using BitirmeProjesi.Common.DTOs.Base;
using BitirmeProjesi.Common.DTOs.CartItem;
using System;
using System.Collections.Generic;

namespace BitirmeProjesi.Common.DTOs.Cart
{
    public class CartResponse : BaseDto
    {
        public CartResponse()
        {
            CartItem = new List<CartItemResponse>();
        }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public int MemberId { get; set; }
        public int ShopTokensId { get; set; }
        public List<CartItemResponse> CartItem { get; set; }
    }
}
