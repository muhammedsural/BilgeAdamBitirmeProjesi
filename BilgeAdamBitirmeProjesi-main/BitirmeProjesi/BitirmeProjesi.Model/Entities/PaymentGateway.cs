using BitirmeProjesi.Core.Entity;
namespace BitirmeProjesi.Model.Entities
{
    public class PaymentGateway : CoreEntity
    {
        public string code { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public PaymentProvider paymentProviderId { get; set; }

    }
}
