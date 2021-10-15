using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace BitirmeProjesi.Web.UI.Areas.Admin.Models.UpdateProductViewModels
{
    public class UpdateProductViewModel
    {
        public int Id { get; set; }
        public string name { get; set; } //
        public string fullName { get; set; } //
        public decimal price { get; set; } //
        public string type { get; set; }
        public string productImage { get; set; } //
        public int? tax { get; set; }
        public decimal? stockAmount { get; set; } //
        public string stockTypeLabel { get; set; }
        public bool status { get; set; } //
        public bool? taxIncluded { get; set; } //
        public string searchKeywords { get; set; }
        public int brandId { get; set; } //
        public int categoryId { get; set; } //
        public string? detail { get; set; }//
       
    }
}