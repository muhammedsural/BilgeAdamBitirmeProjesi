using BitirmeProjesi.Common.DTOs.Base;
namespace BitirmeProjesi.Common.DTOs.ProductToCategory
{
    public class ProductToCategoryResponse : BaseDto
    {
        public int productId { get; set; }
        public int categoryId { get; set; }
    }
}
