using BitirmeProjesi.Common.DTOs.Base;
namespace BitirmeProjesi.Common.DTOs.MemberAddress
{
    public class MemberAddressRequest : BaseDto
    {
        public string adresType { get; set; }
        public string firstname { get; set; }
        public string surname { get; set; }
        public string address { get; set; }
        public string phonenumber { get; set; }
        public string mobilePhonenumber { get; set; }
        public int? tcId { get; set; }
        public string invoiceType { get; set; }
        public bool? isEinvoiceUser { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public int memberId { get; set; }
        public int countryId { get; set; }
        public int locationId { get; set; }
        public int subLocationId { get; set; }
    }
}
