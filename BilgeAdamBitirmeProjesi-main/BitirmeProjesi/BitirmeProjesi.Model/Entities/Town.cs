using BitirmeProjesi.Core.Entity;
namespace BitirmeProjesi.Model.Entities
{
    public class Town : CoreEntity
    {
        public string name { get; set; }
        public bool status { get; set; }
        public Location locationId { get; set; }

    }
}
