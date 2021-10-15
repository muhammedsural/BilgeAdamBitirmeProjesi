using BitirmeProjesi.Common.DTOs.Base;
namespace BitirmeProjesi.Common.DTOs.Options
{
    public class OptionsRequest : BaseDto
    {
        public string title { get; set; }
        public int optionGroupId { get; set; }
    }
}
