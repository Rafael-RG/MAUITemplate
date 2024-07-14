using Backend.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Backend.DataAccess
{
    /// <summary>
    /// Generic class for a repository 
    /// </summary>
    /// <remarks>   
    public class Repository<TEntity>(DatabaseContext context) : IRepository<TEntity> where TEntity : class
    {
        private readonly DatabaseContext context = context;
        private readonly DbSet<TEntity> dbSet = context.Set<TEntity>();
     

        public virtual async Task<int> CountAsync()
        {
            IQueryable<TEntity> query = dbSet;
            return await query.CountAsync();
        }


        /// <inheritdoc/>     
        public virtual async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", int? page = null, int? pageSize = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            char[] separator = [','];
            foreach (var includeProperty in includeProperties.Split
                (separator, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                return (page != null && pageSize != null) ?
                   await orderBy(query).Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value).ToListAsync()
                 : await orderBy(query).ToListAsync();

            }
            else
            {
                return await query.ToListAsync();
            }
        }


        /// <inheritdoc/>     
        public virtual async Task<IEnumerable<TResult>> GetAsync<TResult>(
            Expression<Func<TEntity, TResult>> select = null,
            Expression<Func<TEntity, bool>> filter = null,
            Expression<Func<TEntity, TEntity>> keySelector = null,
            

            Func<IQueryable<TResult>, IOrderedQueryable<TResult>> orderBy = null,
            string includeProperties = "", int? page = null, int? pageSize = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            char[] separator = [','];
            foreach (var includeProperty in includeProperties.Split
                (separator, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            var result = query.Select(select);       
            if (orderBy != null)
            {             
                return (page!=null && pageSize!=null) 
                    ? await orderBy(result).Skip((page.Value -1) * pageSize.Value).Take(pageSize.Value).ToListAsync()
                    : await orderBy(result).ToListAsync();
            }
            else
            {
                return await result.ToListAsync();
            }
        }


        /// <inheritdoc/>     
        public virtual async Task<TEntity> GetAsync(Guid entityId)
        {
            var entity = await dbSet.FindAsync(entityId);
            return entity;
        }


        /// <inheritdoc/>     
        public virtual async Task InsertAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }


        /// <inheritdoc/>     
        public virtual void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }


        /// <inheritdoc/>     
        public virtual void Delete(Guid id)
        {
            TEntity entity = dbSet.Find(id);
            Delete(entity);
        }


        /// <inheritdoc/>     
        public virtual void Delete(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }
    }
}

