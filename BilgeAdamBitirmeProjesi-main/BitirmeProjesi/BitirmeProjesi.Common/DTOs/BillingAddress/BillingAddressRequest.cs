using BitirmeProjesi.Common.DTOs.Base;

namespace BitirmeProjesi.Common.DTOs.BillingAddress
{
    public class BillingAddressRequest : BaseDto
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
        
        public string invoiceType { get; set; }
        public int taxNo { get; set; }
        
        public string taxOffice { get; set; }
        public int identityRegistrationnumber { get; set; }



    }
}
