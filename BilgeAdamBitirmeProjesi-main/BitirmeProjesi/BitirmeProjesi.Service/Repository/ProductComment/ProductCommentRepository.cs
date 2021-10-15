using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.Base;
using EF = BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.Service.Repository.ProductComment
{
    public class ProductCommentRepository : Repository<EF.ProductComment>,
        IProductCommentRepository
    {
        private readonly DataContext _dataContext;

        public ProductCommentRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}