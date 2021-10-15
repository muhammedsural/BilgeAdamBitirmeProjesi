using System.Collections.Generic;

namespace BitirmeProjesi.Web.UI.Areas.Admin.Models.BrandViewModels
{
    public class AdminBrandViewModel
    {
        public UpdateBrandViewModel updateBrandViewModel { get; set; }
        public List<BrandViewModel> brandViewModels { get; set; }
    }
}