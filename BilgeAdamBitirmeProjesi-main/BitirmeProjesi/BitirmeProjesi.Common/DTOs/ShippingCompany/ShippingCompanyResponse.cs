using BitirmeProjesi.Common.DTOs.Base;
namespace BitirmeProjesi.Common.DTOs.ShippingCompany
{
    public class ShippingCompanyResponse : BaseDto
    {
        public string name { get; set; }
        public string status { get; set; }
        public int? extraPrice { get; set; }
        public int shippingProviderId { get; set; }
    }
}
