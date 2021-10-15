using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using BitirmeProjesi.Service.Repository.OrderUserNote;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.Payment
{
    public class PaymentRepository : Repository<EF.Payment>,
        IPaymentRepository
    {
        private readonly DataContext _dataContext;

        public PaymentRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}