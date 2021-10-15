using System.Collections.Generic;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.BrandViewModels;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.CategoryViewModels;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.UpdateProductViewModels;

namespace BitirmeProjesi.Web.UI.Areas.Admin.Models.ProductViewModels
{
    public class AdminProductViewModel
    {
        public List<ProductViewModel> productViewModels { get; set; }
        public UpdateProductViewModel updateProductViewModel { get; set; }
        public List<CategoryViewModel> categoryViewModels { get; set; }
        public List<BrandViewModel> brandViewModels { get; set; }
    }
}