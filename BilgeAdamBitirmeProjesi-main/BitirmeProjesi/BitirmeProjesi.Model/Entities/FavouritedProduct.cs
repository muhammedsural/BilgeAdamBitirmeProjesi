using BitirmeProjesi.Core.Entity;

namespace BitirmeProjesi.Model.Entities
{
    public class FavouritedProduct : CoreEntity
    {

        public Member memberId { get; set; }
        public Product productId { get; set; }
    }
}
