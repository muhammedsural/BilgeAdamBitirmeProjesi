using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using BitirmeProjesi.Service.Repository.OptionToProduct;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.Order
{
    public class OrderRepository : Repository<EF.Order>, IOrderRepository
    {
        private readonly DataContext _dataContext;

        public OrderRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}