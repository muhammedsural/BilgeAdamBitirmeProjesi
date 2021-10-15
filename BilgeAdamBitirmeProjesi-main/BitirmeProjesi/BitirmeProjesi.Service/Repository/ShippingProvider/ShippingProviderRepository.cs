using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using BitirmeProjesi.Service.Repository.ShippingCompany;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.ShippingProvider
{
    public class ShippingProviderRepository : Repository<EF.ShippingProvider>,
        IShippingProviderRepository
    {
        private readonly DataContext _dataContext;

        public ShippingProviderRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}