using BitirmeProjesi.Core.Repository;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.OrderAddress

{
    public interface IOrderAddressRepository : IRepository<EF.OrderAddress>
    {
    }
}