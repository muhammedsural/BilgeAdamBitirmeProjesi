using BitirmeProjesi.Core.Entity;

namespace BitirmeProjesi.Model.Entities
{
    public class SpecGroup : CoreEntity
    {
        public string name { get; set; }
        public int? sortOrder { get; set; }
        public bool status { get; set; }
    }
}
