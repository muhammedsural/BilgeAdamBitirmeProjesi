using BitirmeProjesi.Core.Repository;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.Order

{
    public interface IOrderRepository : IRepository<EF.Order>
    {
    }
}