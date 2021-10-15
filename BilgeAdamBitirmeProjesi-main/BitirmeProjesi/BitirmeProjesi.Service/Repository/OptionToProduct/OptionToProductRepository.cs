using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using BitirmeProjesi.Service.Repository.Options;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.OptionToProduct
{
    public class OptionToProductRepository : Repository<EF.OptionToProduct>, IOptionToProductRepository
    {
        private readonly DataContext _dataContext;

        public OptionToProductRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}