using BitirmeProjesi.Common.DTOs.Base;
namespace BitirmeProjesi.Common.DTOs.PaymentGateway
{
    public class PaymentGatewayRequest : BaseDto
    {
        public string code { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public int paymentProviderId { get; set; }
    }
}
