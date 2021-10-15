using BitirmeProjesi.Core.Entity;

namespace BitirmeProjesi.Model.Entities
{
    public class BillingAddress : CoreEntity
    {
        public string firstname { get; set; }

        public string surname { get; set; }

        public string country { get; set; }

        public string location { get; set; }

        public string subLocation { get; set; }

        public string address { get; set; }

        public string phonenumber { get; set; }

        public string mobilePhonenumber { get; set; }
        
        public Order Order { get; set; }
        public int orderId { get; set; }
        public string invoiceType { get; set; }
        public int taxNo { get; set; }

        public string taxOffice { get; set; }
        public int identityRegistrationnumber { get; set; }
    }
}