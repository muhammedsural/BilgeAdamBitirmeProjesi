using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using BitirmeProjesi.Service.Repository.Maillist;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.MaillistGroup
{
    public class MaillistGroupRepository : Repository<EF.MaillistGroup>, IMaillistGroupRepository
    {
        private readonly DataContext _dataContext;

        public MaillistGroupRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}