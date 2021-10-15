using BitirmeProjesi.Core.Repository;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.Country

{
    public interface ICountryRepository : IRepository<EF.Country>
    {
    }
}