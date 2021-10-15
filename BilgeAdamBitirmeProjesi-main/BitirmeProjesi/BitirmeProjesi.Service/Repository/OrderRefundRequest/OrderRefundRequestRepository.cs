using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.OrderRefundRequest
{
    public class OrderRefundRequestRepository : Repository<EF.OrderRefundRequest>, IOrderRefundRequestRepository
    {
        private readonly DataContext _dataContext;

        public OrderRefundRequestRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}