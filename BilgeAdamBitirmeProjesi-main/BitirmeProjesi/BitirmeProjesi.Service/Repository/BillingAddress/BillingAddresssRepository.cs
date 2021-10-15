using System.Threading.Tasks;
using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.BillingAddress
{
    public class BillingAddressRepository : Repository<EF.BillingAddress>, IBillingAddressRepository
    {
        private readonly DataContext _dataContext;

        public BillingAddressRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }

        public Task Update(EF.BillingAddress entity)
        {
            throw new System.NotImplementedException();
        }
    }
}