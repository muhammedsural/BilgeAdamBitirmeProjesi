using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.Product
{
    public class ProductRepository : Repository<EF.Product>,
        IProductRepository
    {
        private readonly DataContext _dataContext;

        public ProductRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}