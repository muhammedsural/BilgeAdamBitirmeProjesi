using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using BitirmeProjesi.Service.Repository.ShippingAddress;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.ShippingCompany
{
    public class ShippingCompanyRepository : Repository<EF.ShippingCompany>,
        IShippingCompanyRepository
    {
        private readonly DataContext _dataContext;

        public ShippingCompanyRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}