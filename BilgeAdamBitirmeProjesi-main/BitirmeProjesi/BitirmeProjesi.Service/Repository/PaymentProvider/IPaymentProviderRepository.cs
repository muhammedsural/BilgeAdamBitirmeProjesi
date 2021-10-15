using BitirmeProjesi.Core.Repository;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.PaymentProvider

{
    public interface IPaymentProviderRepository : IRepository<EF.PaymentProvider>
    {
    }
}