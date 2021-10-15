using BitirmeProjesi.Core.Repository;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.ShippingAddress

{
    public interface IShippingAddressRepository : IRepository<EF.ShippingAddress>
    {
    }
}