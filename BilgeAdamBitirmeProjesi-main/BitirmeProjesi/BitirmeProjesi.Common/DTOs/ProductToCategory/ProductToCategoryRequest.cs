using BitirmeProjesi.Common.DTOs.Base;
namespace BitirmeProjesi.Common.DTOs.ProductToCategory
{
    public class ProductToCategoryRequest : BaseDto
    {
        public int productId { get; set; }
        public int categoryId { get; set; }
    }
}
