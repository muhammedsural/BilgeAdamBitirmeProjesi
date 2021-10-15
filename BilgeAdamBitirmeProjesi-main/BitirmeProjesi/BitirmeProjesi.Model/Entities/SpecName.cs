using BitirmeProjesi.Core.Entity;
namespace BitirmeProjesi.Model.Entities
{
    public class SpecName : CoreEntity
    {
        public string name { get; set; }
        public SpecGroup specGroupId { get; set; }
    }
}
