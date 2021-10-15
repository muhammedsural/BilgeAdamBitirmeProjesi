using BitirmeProjesi.Core.Entity;

namespace BitirmeProjesi.Model.Entities
{
    public class SpecToProduct : CoreEntity
    {
        public Product productId { get; set; }
        public SpecGroup specGroupId { get; set; }
        public SpecName specNameId { get; set; }
        public SpecValue specValueId { get; set; }
    }
}
