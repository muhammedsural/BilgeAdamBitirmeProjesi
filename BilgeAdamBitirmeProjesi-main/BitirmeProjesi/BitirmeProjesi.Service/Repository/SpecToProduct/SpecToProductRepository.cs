using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using BitirmeProjesi.Service.Repository.SpecName;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.SpecToProduct
{
    public class SpecToProductRepository : Repository<EF.SpecToProduct>,
        ISpecToProductRepository
    {
        private readonly DataContext _dataContext;

        public SpecToProductRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}