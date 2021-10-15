using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using BitirmeProjesi.Service.Repository.OptionGroup;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.Options
{
    public class OptionsRepository : Repository<EF.Options>, IOptionsRepository
    {
        private readonly DataContext _dataContext;

        public OptionsRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}