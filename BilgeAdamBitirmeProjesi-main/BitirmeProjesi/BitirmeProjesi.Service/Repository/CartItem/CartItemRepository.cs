using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.CartItem
{
    public class CartItemRepository : Repository<EF.CartItem>, ICartItemRepository
    {
        private readonly DataContext _dataContext;

        public CartItemRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}