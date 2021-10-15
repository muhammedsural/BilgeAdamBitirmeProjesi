using BitirmeProjesi.Core.Repository;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.OrderRefundRequest

{
    public interface IOrderRefundRequestRepository : IRepository<EF.OrderRefundRequest>
    {
    }
}