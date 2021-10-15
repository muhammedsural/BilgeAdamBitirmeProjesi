using BitirmeProjesi.Common.DTOs.Base;
namespace BitirmeProjesi.Common.DTOs.ShippingProvider
{
    public class ShippingProviderRequest : BaseDto
    {
        public string code { get; set; }
        public string name { get; set; }
    }
}
