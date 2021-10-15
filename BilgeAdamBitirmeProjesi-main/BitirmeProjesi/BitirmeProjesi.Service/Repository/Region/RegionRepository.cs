using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.Region
{
    public class RegionRepository : Repository<EF.Region>,
        IRegionRepository
    {
        private readonly DataContext _dataContext;

        public RegionRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}