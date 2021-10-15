using BitirmeProjesi.Common.DTOs.Base;
namespace BitirmeProjesi.Common.DTOs.SpecValue
{
    public class SpecValueRequest : BaseDto
    {
        public string name { get; set; }
        public bool status { get; set; }
        public int specGroupId { get; set; }
        public int specNameId { get; set; }
    }
}
