using BitirmeProjesi.Core.Entity;

namespace BitirmeProjesi.Model.Entities
{
    public class Options : CoreEntity
    {

        public string title { get; set; }
        public OptionGroup optionGroupId { get; set; }
    }
}
