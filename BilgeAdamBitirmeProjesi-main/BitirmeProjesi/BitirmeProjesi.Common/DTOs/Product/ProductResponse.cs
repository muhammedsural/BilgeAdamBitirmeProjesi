using BitirmeProjesi.Common.DTOs.Base;
using System;

namespace BitirmeProjesi.Common.DTOs.Product
{
    public class ProductResponse : BaseDto
    {
        public string name { get; set; }
        public string fullName { get; set; }
        public string type { get; set; }
        public decimal price { get; set; }
        public int? tax { get; set; }
        public decimal? stockAmount { get; set; }
        public string stockTypeLabel { get; set; }
        public bool status { get; set; }
        public bool? taxIncluded { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public bool hasOption { get; set; }
        public string searchKeywords { get; set; }
        public int brandId { get; set; }
        public int categoryId { get; set; }
        public string detail { get; set; }
        public string productImage { get; set; } //
    }
}