using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.Category
{
    public class CategoryRepository : Repository<EF.Category>, ICategoryRepository
    {
        private readonly DataContext _dataContext;

        public CategoryRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}