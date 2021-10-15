using BitirmeProjesi.Core.Entity;

namespace BitirmeProjesi.Model.Entities
{
    public class OptionToProduct : CoreEntity
    {
        public int parentProductId { get; set; }
        public OptionGroup optionGroupId { get; set; }
        public Options optionId { get; set; }
        public Product productId { get; set; }

    }
}
