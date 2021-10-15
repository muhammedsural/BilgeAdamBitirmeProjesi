using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.PaymentProvider
{
    public class PaymentProviderRepository : Repository<EF.PaymentProvider>,
        IPaymentProviderRepository
    {
        private readonly DataContext _dataContext;

        public PaymentProviderRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}