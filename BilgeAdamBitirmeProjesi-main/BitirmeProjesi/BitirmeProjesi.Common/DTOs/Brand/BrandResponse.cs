using BitirmeProjesi.Common.DTOs.Base;
using System;

namespace BitirmeProjesi.Common.DTOs.Brand
{
    public class BrandResponse : BaseDto
    {
        public string name { get; set; }
        public bool status { get; set; }
        public string brandImage { get; set; }
        public string? pageTitle { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
    }
}