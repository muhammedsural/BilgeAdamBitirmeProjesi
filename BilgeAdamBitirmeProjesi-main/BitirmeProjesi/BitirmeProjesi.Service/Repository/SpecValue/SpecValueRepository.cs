using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using BitirmeProjesi.Service.Repository.SpecToProduct;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.SpecValue
{
    public class SpecValueRepository : Repository<EF.SpecValue>,
        ISpecValueRepository
    {
        private readonly DataContext _dataContext;

        public SpecValueRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}