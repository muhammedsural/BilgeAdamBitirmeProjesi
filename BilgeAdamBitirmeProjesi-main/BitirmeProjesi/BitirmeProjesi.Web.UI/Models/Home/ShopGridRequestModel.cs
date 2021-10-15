using System.Reflection.Metadata.Ecma335;

namespace BitirmeProjesi.Web.UI.Models.Home
{
    public class ShopGridRequestModel
    {
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int Page { get; set; }
        public int Sort { get; set; }
    }
}