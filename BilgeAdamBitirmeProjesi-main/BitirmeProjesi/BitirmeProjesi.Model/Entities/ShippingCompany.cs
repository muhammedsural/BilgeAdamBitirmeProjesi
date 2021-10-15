using BitirmeProjesi.Core.Entity;

namespace BitirmeProjesi.Model.Entities
{
    public class ShippingCompany : CoreEntity
    {
        public string name { get; set; }
        public string status { get; set; }
        public int? extraPrice { get; set; }
        public ShippingProvider shippingProviderId { get; set; }
    }
}
