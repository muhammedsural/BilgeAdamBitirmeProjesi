using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.MemberAddress
{
    public class MemberAddressRepository : Repository<EF.MemberAddress>, IMemberAddressRepository
    {
        private readonly DataContext _dataContext;

        public MemberAddressRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}