using BitirmeProjesi.Core.Repository;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.Payment

{
    public interface IPaymentRepository : IRepository<EF.Payment>
    {
    }
}