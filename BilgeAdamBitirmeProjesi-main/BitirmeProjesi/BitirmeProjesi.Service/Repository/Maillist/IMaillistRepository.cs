using BitirmeProjesi.Core.Repository;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.Maillist

{
    public interface IMaillistRepository : IRepository<EF.Maillist>
    {
    }
}