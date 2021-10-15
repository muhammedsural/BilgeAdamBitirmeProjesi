using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.OptionGroup
{
    public class OptionGroupRepository : Repository<EF.OptionGroup>, IOptionGroupRepository
    {
        private readonly DataContext _dataContext;

        public OptionGroupRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}