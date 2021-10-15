using BitirmeProjesi.Common.DTOs.Base;
namespace BitirmeProjesi.Common.DTOs.Town
{
    public class TownResponse : BaseDto
    {
        public string name { get; set; }
        public bool status { get; set; }
        public int locationId { get; set; }
       
    }
}
