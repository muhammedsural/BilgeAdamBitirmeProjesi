using BitirmeProjesi.Common.DTOs.Base;
namespace BitirmeProjesi.Common.DTOs.PaymentProvider
{
    public class PaymentProviderRequest : BaseDto
    {
        public string code { get; set; }
        public string name { get; set; }
        public bool status { get; set; }
        public int paymentTypeId { get; set; }
    }
}
