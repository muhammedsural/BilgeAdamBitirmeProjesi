using BitirmeProjesi.Common.DTOs.Base;
namespace BitirmeProjesi.Common.DTOs.ProductToTag
{
    public class ProductToTagRequest : BaseDto
    {
        public int productId { get; set; }
        public int tagId { get; set; }
    }
}
