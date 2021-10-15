using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.Brand
{
    public class BrandRepository : Repository<EF.Brand>, IBrandRepository
    {
        private readonly DataContext _dataContext;

        public BrandRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}