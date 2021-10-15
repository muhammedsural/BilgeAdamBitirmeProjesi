using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.OrderItem
{
    public class OrderItemRepository : Repository<EF.OrderItem>, IOrderItemRepository
    {
        private readonly DataContext _dataContext;

        public OrderItemRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}