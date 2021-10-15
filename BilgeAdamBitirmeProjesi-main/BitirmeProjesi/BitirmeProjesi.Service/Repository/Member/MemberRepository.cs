using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.Member
{
    public class MemberRepository : Repository<EF.Member>, IMemberRepository
    {
        private readonly DataContext _dataContext;

        public MemberRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}