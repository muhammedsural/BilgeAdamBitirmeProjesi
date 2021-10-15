using BitirmeProjesi.Core.Entity;
namespace BitirmeProjesi.Model.Entities
{
    public class OrderAddress : CoreEntity
    {
        public string firstname { get; set; }
        public string surname { get; set; }
        public string country { get; set; }
        public string location { get; set; }
        public string subLocation { get; set; }
        public string address { get; set; }
        public string phonenumber { get; set; }
        public string mobilePhonenumber { get; set; }
        public Order orderId { get; set; }
    }
}
