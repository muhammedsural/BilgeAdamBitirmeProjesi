using BitirmeProjesi.Common.DTOs.Base;

namespace BitirmeProjesi.Common.DTOs.FavouritedProduct
{
    public class FavouritedProductResponse : BaseDto
    {
        public int memberId { get; set; }
        public int productId { get; set; }
    }
}
