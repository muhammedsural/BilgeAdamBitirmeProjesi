using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.SpecGroup
{
    public class SpecGroupRepository : Repository<EF.SpecGroup>,
        ISpecGroupRepository
    {
        private readonly DataContext _dataContext;

        public SpecGroupRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}