using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using BitirmeProjesi.Service.Repository.OrderRefundRequestItem;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.OrderUserNote
{
    public class OrderUserNoteRepository : Repository<EF.OrderUserNote>,
        IOrderUserNoteRepository
    {
        private readonly DataContext _dataContext;

        public OrderUserNoteRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}