using System.Collections.Generic;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.BrandViewModels;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.CategoryViewModels;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.ProductViewModels;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.UpdateProductViewModels;

namespace BitirmeProjesi.Web.UI.Areas.Admin.Models.CategoryViewModels
{
    public class AdminCategoryViewModel
    {
        public UpdateCategoryViewModel updateCategoryViewModel { get; set; }
        public List<CategoryViewModel> categoryViewModels { get; set; }
    }
}