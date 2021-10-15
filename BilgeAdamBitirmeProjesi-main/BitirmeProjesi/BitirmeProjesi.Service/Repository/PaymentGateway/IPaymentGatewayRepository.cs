using BitirmeProjesi.Core.Repository;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.PaymentGateway

{
    public interface IPaymentGatewayRepository : IRepository<EF.PaymentGateway>
    {
    }
}