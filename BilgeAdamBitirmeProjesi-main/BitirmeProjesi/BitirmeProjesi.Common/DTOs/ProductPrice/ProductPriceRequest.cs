using BitirmeProjesi.Common.DTOs.Base;
namespace BitirmeProjesi.Common.DTOs.ProductPrice
{
    public class ProductPriceRequest : BaseDto
    {
        public decimal value { get; set; }
        public int productId { get; set; }
    }
}
