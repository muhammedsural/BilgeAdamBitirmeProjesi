
namespace BitirmeProjesi.Common.DTOs.Product
{
    public class ShopGridRequestModelDTO
    {
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int Page { get; set; }
        public int Sort { get; set; }
    }
}
