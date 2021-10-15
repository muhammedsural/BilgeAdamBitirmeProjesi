using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using BitirmeProjesi.Core.Entity;
using BitirmeProjesi.Core.Repository;
using BitirmeProjesi.Model.Context;

namespace BitirmeProjesi.Service.Repository.Base
{
    public class Repository<T> : IRepository<T> where T : CoreEntity
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        private DbSet<T> _entities;

        public DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }

        public async Task<bool> Remove(int id)
        {
            T silinecek = Entities.Find(id);
            _entities.Remove(silinecek);
            if (await Save() > 0)
                return true;
            else
                return false;
        }

        public IQueryable<T> Table
        {
            get { return Entities; }
        }

        public IQueryable<T> TableNoTracking
        {
            get { return Entities.AsNoTracking(); }
        }

        public async Task<T> Add(T item)
        {
            try
            {
                if (item == null)
                    return null;

                await Entities.AddAsync(item);

                if (await Save() > 0)
                    return item;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> AddRange(List<T> items)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    await Entities.AddRangeAsync(items);
                    int result = await Save();
                    if (result > 0)
                    {
                        ts.Complete();
                        return result > 0;
                    }

                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> Update(T item)
        {
            try
            {
                if (item == null)
                    return null;

                Entities.Update(item);

                if (await Save() > 0)
                    return item;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Any(Expression<Func<T, bool>> exp) => await Entities.AnyAsync(exp);


        public async Task<T> GetByDefault(Expression<Func<T, bool>> exp,
            params Expression<Func<T, object>>[] includeParameters)
        {
            IQueryable<T> queryable = TableNoTracking;
            foreach (Expression<Func<T, object>> includeParameter in includeParameters)
            {
                queryable = queryable.Include(includeParameter);
            }

            return await queryable.FirstOrDefaultAsync();
        }

        public async Task<T> GetById(int id, params Expression<Func<T, object>>[] includeParameters)
        {
            IQueryable<T> queryable = TableNoTracking;
            foreach (Expression<Func<T, object>> includeParameter in includeParameters)
            {
                queryable = queryable.Include(includeParameter);
            }

            return await queryable.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> GetDefault(Expression<Func<T, bool>> exp,
            params Expression<Func<T, object>>[] includeParameters)
        {
            IQueryable<T> queryable = TableNoTracking;
            foreach (Expression<Func<T, object>> includeParameter in includeParameters)
            {
                queryable = queryable.Include(includeParameter);
            }

            return await queryable.Where(exp).FirstOrDefaultAsync();
        }


        public async Task<int> Save() => await _context.SaveChangesAsync();
    }
}