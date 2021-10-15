using BitirmeProjesi.Common.DTOs.Base;
using System;

namespace BitirmeProjesi.Common.DTOs.Category
{
    public class CategoryRequest : BaseDto
    {
        public string name { get; set; }
        public bool status { get; set; }
        public string? metaKeywords { get; set; }
        public string? metaDescription { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
    }
}