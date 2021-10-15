using BitirmeProjesi.Core.Entity;
using System;
using System.Collections.Generic;

namespace BitirmeProjesi.Model.Entities
{
    public class Product : CoreEntity
    {
        public Product()
        {
            cartItems = new HashSet<CartItem>();
        }
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
        public string searchKeywords { get; set; }
        public int brandId { get; set; }
        public Brand brand { get; set; }
        public int categoryId { get; set; }
        public Category category { get; set; }
        public string detail { get; set; }
        public string productImage { get; set; }
        public ICollection<CartItem> cartItems { get; set; }
    }
}