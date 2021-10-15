using BitirmeProjesi.Common.DTOs.Base;

namespace BitirmeProjesi.Common.DTOs.Country
{
    public class CountryRequest : BaseDto
    {

        public string name { get; set; }
        public bool status { get; set; }
    }
}
