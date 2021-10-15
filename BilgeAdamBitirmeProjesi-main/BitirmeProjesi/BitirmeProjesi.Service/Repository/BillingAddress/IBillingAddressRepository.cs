using BitirmeProjesi.Core.Repository;
using System.Threading.Tasks;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.BillingAddress

{
    public interface IBillingAddressRepository : IRepository<EF.BillingAddress>
    {
      
    }
}