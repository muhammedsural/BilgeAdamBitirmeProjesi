using BitirmeProjesi.Core.Entity;
namespace BitirmeProjesi.Model.Entities
{
    public class SpecValue : CoreEntity
    {
        public string name { get; set; }
        public bool status { get; set; }
        public SpecGroup specGroupId { get; set; }
        public SpecName specNameId { get; set; }
    }
}
