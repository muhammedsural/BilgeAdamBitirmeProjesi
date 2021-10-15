using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.FavouritedProduct
{
    public class FavouritedProductRepository : Repository<EF.FavouritedProduct>, IFavouritedProductRepository
    {
        private readonly DataContext _dataContext;

        public FavouritedProductRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}