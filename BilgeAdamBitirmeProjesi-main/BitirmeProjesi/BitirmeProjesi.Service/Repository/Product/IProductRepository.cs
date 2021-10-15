using BitirmeProjesi.Core.Repository;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.Product

{
    public interface IProductRepository : IRepository<EF.Product>
    {
    }
}