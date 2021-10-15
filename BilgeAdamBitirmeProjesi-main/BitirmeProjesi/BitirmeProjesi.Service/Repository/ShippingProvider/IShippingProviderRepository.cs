using BitirmeProjesi.Core.Repository;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.ShippingProvider

{
    public interface IShippingProviderRepository : IRepository<EF.ShippingProvider>
    {
    }
}