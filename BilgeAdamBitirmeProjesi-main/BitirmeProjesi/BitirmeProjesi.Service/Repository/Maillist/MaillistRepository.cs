using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using BitirmeProjesi.Service.Repository.Location;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.Maillist
{
    public class MaillistRepository : Repository<EF.Maillist>, IMaillistRepository
    {
        private readonly DataContext _dataContext;

        public MaillistRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}