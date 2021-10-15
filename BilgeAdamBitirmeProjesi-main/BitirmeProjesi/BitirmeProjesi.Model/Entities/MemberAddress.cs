using BitirmeProjesi.Core.Entity;

namespace BitirmeProjesi.Model.Entities
{
    public class MemberAddress : CoreEntity
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
        public Member memberId { get; set; }
        public Country countryId { get; set; }
        public Location locationId { get; set; }
        public Town subLocationId { get; set; }

    }
}
