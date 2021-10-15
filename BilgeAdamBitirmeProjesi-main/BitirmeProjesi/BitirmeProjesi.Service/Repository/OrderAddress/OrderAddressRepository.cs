using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using BitirmeProjesi.Service.Repository.Order;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.OrderAddress
{
    public class OrderAddressRepository : Repository<EF.OrderAddress>, IOrderAddressRepository
    {
        private readonly DataContext _dataContext;

        public OrderAddressRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}