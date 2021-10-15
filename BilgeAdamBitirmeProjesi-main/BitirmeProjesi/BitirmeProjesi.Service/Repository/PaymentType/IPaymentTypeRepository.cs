using BitirmeProjesi.Core.Repository;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.PaymentType

{
    public interface IPaymentTypeRepository : IRepository<EF.PaymentType>
    {
    }
}