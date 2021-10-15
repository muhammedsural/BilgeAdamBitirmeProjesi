using BitirmeProjesi.Core.Repository;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.FavouritedProduct

{
    public interface IFavouritedProductRepository : IRepository<EF.FavouritedProduct>
    {
    }
}