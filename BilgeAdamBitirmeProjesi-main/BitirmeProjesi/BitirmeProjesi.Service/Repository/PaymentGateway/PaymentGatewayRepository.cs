using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using BitirmeProjesi.Service.Repository.Payment;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.PaymentGateway
{
    public class PaymentGatewayRepository : Repository<EF.PaymentGateway>,
        IPaymentGatewayRepository
    {
        private readonly DataContext _dataContext;

        public PaymentGatewayRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}