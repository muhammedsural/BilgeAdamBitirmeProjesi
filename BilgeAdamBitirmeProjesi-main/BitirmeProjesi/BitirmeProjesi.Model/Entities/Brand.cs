using BitirmeProjesi.Core.Entity;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BitirmeProjesi.Model.Entities
{
    public class Brand : CoreEntity
    {
        public Brand()
        {
            products = new HashSet<Product>();
        }

        public string name { get; set; }
        public bool status { get; set; }
        public string brandImage { get; set; }
        public string? pageTitle { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public ICollection<Product> products { get; set; }
    }
}