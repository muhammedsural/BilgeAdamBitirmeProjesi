using BitirmeProjesi.Core.Repository;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.CartItem

{
    public interface ICartItemRepository : IRepository<EF.CartItem>
    {
    }
}