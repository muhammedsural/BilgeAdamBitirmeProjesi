using System;
using System.Collections.Generic;


namespace BitirmeProjesi.Web.UI.Areas.Admin.Models.CartViewModels
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public int productId { get; set; }
        public string name { get; set; }
        public decimal quantity { get; set; }
        public decimal  price { get; set; }
        public string base64 { get; set; }
    }
}