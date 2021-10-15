﻿using BitirmeProjesi.Common.DTOs.Base;
namespace BitirmeProjesi.Common.DTOs.ProductDetail
{
    public class ProductDetailRequest : BaseDto
    {
        public string details { get; set; }
        public string extraDetails { get; set; }
        public int productId { get; set; }
    }
}
