using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.Country
{
    public class CountryRepository : Repository<EF.Country>, ICountryRepository
    {
        private readonly DataContext _dataContext;

        public CountryRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}