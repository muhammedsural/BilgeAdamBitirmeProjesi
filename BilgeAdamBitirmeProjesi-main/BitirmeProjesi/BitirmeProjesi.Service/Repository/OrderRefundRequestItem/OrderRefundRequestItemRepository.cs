using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using BitirmeProjesi.Service.Repository.OrderRefundRequest;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.OrderRefundRequestItem
{
    public class OrderRefundRequestItemRepository : Repository<EF.OrderRefundRequestItem>,
        IOrderRefundRequestItemRepository
    {
        private readonly DataContext _dataContext;

        public OrderRefundRequestItemRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}