using BitirmeProjesi.Core.Repository;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.Member

{
    public interface IMemberRepository : IRepository<EF.Member>
    {
    }
}
