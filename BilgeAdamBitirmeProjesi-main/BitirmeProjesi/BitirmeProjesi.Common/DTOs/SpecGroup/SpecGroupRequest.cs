using BitirmeProjesi.Common.DTOs.Base;
namespace BitirmeProjesi.Common.DTOs.SpecGroup
{
    public class SpecGroupRequest : BaseDto
    {
        public string name { get; set; }
        public int? sortOrder { get; set; }
        public bool status { get; set; }
    }
}
