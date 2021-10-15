using BitirmeProjesi.Common.DTOs.Base;
namespace BitirmeProjesi.Common.DTOs.ShippingAddress
{
    public class ShippingAddressRequest : BaseDto
    {
        public string firstname { get; set; }
        public string surname { get; set; }
        public string country { get; set; }
        public string location { get; set; }
        public string subLocation { get; set; }
        public string address { get; set; }
        public string phonenumber { get; set; }
        public string mobilePhonenumber { get; set; }
        public int orderId { get; set; }
    }
}
