using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.Cart
{
    public class CartRepository : Repository<EF.Cart>, ICartRepository
    {
        private readonly DataContext _dataContext;

        public CartRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}