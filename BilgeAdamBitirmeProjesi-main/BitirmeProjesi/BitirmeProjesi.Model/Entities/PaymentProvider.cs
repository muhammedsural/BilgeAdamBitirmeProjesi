using BitirmeProjesi.Core.Entity;
namespace BitirmeProjesi.Model.Entities
{
    public class PaymentProvider : CoreEntity
    {
        public string code { get; set; }
        public string name { get; set; }
        public bool status { get; set; }
        public PaymentType paymentTypeId { get; set; }
    }
}
