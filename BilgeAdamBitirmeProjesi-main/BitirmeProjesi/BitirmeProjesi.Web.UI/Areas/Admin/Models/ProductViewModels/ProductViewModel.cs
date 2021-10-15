using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.CategoryViewModels;

namespace BitirmeProjesi.Web.UI.Areas.Admin.Models.ProductViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string fullName { get; set; }
        public decimal price { get; set; }
        public string type { get; set; }
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
      
        public string productImage { get; set; } 
    }
}