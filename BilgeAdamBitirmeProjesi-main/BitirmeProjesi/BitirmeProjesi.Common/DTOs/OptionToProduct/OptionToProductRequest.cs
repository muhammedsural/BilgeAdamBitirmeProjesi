using BitirmeProjesi.Common.DTOs.Base;
namespace BitirmeProjesi.Common.DTOs.OptionToProduct
{
    public class OptionToProductRequest : BaseDto
    {
        public int parentProductId { get; set; }
        public int optionGroupId { get; set; }
        public int optionId { get; set; }
        public int productId { get; set; }
    }
}
