using BitirmeProjesi.Core.Repository;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.ProductComment

{
    public interface IProductCommentRepository : IRepository<EF.ProductComment>
    {
    }
}