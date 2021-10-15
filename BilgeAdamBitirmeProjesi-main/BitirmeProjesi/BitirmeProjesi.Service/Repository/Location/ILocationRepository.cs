using BitirmeProjesi.Core.Repository;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.Location

{
    public interface ILocationRepository : IRepository<EF.Location>
    {
    }
}