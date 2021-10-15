using BitirmeProjesi.Common.DTOs.Base;
namespace BitirmeProjesi.Common.DTOs.SpecToProduct
{
    public class SpecToProductRequest : BaseDto
    {
        public int productId { get; set; }
        public int specGroupId { get; set; }
        public int specNameId { get; set; }
        public int specValueId { get; set; }
    }
}
