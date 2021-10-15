using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.Location
{
    public class LocationRepository : Repository<EF.Location>, ILocationRepository
    {
        private readonly DataContext _dataContext;

        public LocationRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}