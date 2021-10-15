using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.Town
{
    public class TownRepository : Repository<EF.Town>,
        ITownRepository
    {
        private readonly DataContext _dataContext;

        public TownRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}