using BitirmeProjesi.Common.DTOs.Base;
namespace BitirmeProjesi.Common.DTOs.ProductPrice
{
    public class ProductPriceResponse : BaseDto
    {
        public decimal value { get; set; }
        public int productId { get; set; }
    }
}
