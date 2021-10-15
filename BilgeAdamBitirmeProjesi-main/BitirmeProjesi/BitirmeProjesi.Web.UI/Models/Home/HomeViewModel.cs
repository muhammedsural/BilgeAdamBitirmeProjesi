using System.Collections.Generic;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.BrandViewModels;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.CartViewModels;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.CategoryViewModels;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.ProductViewModels;

namespace BitirmeProjesi.Web.UI.Models.Home
{
    public class HomeViewModel
    {
        public List<BrandViewModel> brandViewModels { get; set; }
        public List<CategoryViewModel> categoryViewModels { get; set; }
        public List<ProductViewModel> productViewModels { get; set; }
        public List<CartViewModel> cartViewModels { get; set; }
    }
}