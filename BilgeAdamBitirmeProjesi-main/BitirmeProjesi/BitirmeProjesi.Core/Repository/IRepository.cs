using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BitirmeProjesi.Core.Entity;

namespace BitirmeProjesi.Core.Repository
{
    public interface IRepository<T> where T : CoreEntity
    {
        Task<T> Add(T item);
        Task<bool> AddRange(List<T> items);
        Task<T> Update(T item);

        Task<T> GetById(int id, params Expression<Func<T, object>>[] includeParameters);
        Task<T> GetByDefault(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includeParameters);
        Task<T> GetDefault(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includeParameters);
        IQueryable<T> Table { get; }
        IQueryable<T> TableNoTracking { get; }
        Task<bool> Remove(int id);
        Task<bool> Any(Expression<Func<T, bool>> exp);
        Task<int> Save();
    }
}