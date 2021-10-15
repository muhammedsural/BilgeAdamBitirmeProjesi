﻿using BitirmeProjesi.Common.DTOs.Base;
using System;

namespace BitirmeProjesi.Common.DTOs.CartItem
{
    public class CartItemResponse : BaseDto
    {
        public int Id { get; set; }
        public decimal quantity { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public int CartId { get; set; }
        public int productId { get; set; }
        
    }
}