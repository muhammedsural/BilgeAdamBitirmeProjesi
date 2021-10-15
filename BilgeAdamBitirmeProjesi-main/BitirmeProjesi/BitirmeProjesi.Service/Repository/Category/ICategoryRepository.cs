using BitirmeProjesi.Core.Repository;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.Category

{
    public interface ICategoryRepository : IRepository<EF.Category>
    {
    }
}