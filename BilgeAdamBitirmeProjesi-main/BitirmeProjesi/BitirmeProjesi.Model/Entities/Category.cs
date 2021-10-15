using BitirmeProjesi.Core.Entity;
using System;
using System.Collections.Generic;

namespace BitirmeProjesi.Model.Entities
{
    public class Category : CoreEntity
    {
        public Category()
        {
            products = new HashSet<Product>();
        }

        public string name { get; set; }
        public bool status { get; set; }
        public string? metaKeywords { get; set; }
        public string? metaDescription { get; set; }


        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public ICollection<Product> products { get; set; }
    }
}