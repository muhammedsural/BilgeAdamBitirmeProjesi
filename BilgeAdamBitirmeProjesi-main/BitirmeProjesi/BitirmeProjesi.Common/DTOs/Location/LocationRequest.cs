using BitirmeProjesi.Common.DTOs.Base;

namespace BitirmeProjesi.Common.DTOs.Location
{
    public class LocationRequest : BaseDto
    {
        public string name { get; set; }
        public bool status { get; set; }
        public bool? predefined { get; set; }
        public int countryid { get; set; }
        public int regionid { get; set; }
    }
}
