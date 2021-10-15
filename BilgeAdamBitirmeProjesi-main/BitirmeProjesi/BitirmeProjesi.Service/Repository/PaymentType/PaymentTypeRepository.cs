using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.PaymentType
{
    public class PaymentTypeRepository : Repository<EF.PaymentType>,
        IPaymentTypeRepository
    {
        private readonly DataContext _dataContext;

        public PaymentTypeRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}