using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.ShippingAddress
{
    public class ShippingAddressRepository : Repository<EF.ShippingAddress>,
        IShippingAddressRepository
    {
        private readonly DataContext _dataContext;

        public ShippingAddressRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}