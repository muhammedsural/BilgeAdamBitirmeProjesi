using System.Collections.Generic;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.CartViewModels;

namespace BitirmeProjesi.Web.UI.Models.Home
{
    public class CheckOrderModel
    {
        public List<CartViewModel> cartViewModels { get; set; }
        public List<CountyViewModel> countyViewModels { get; set; }
        public List<CityViewModel> cityViewModels { get; set; }
    }
}