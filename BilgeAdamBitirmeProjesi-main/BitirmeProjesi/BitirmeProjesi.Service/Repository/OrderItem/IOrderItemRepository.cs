using BitirmeProjesi.Core.Repository;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.OrderItem

{
    public interface IOrderItemRepository : IRepository<EF.OrderItem>
    {
    }
}