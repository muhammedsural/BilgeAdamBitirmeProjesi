using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using BitirmeProjesi.Service.Repository.SpecGroup;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.SpecName
{
    public class SpecNameRepository : Repository<EF.SpecName>,
        ISpecNameRepository
    {
        private readonly DataContext _dataContext;

        public SpecNameRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}