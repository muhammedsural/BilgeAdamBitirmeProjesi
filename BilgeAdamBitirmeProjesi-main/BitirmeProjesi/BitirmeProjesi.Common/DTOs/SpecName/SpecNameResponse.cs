using BitirmeProjesi.Common.DTOs.Base;
namespace BitirmeProjesi.Common.DTOs.SpecName
{
    public class SpecNameResponse : BaseDto
    {
        public string name { get; set; }
        public int specGroupId { get; set; }
    }
}
