using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Backend.Common.Interfaces
{
    /// <summary>
    /// Generic repository interface
    /// </summary>
    public interface IRepository<TEntity> where TEntity : class
    {

        /// <summary>
        /// Returns the amount of elements in the repository
        /// </summary>
        /// <returns></returns>
        Task<int> CountAsync();

        /// <summary>
        /// Insert an entity
        /// </summary>
        Task InsertAsync(TEntity entity);


        /// <summary>
        /// Updates an entity
        /// </summary>
        void Update(TEntity entity);


        /// <summary>
        /// Get an entity
        /// </summary>
        Task<TEntity> GetAsync(Guid entityId);


        /// <summary>
        /// Get a collecion of the entity
        /// </summary>
        Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", int? page = null, int? pageSize = null);

        /// <summary>
        /// Get a collecion of the entity
        /// </summary>
        Task<IEnumerable<TResult>> GetAsync<TResult>(
          Expression<Func<TEntity, TResult>> select = null,          
          Expression<Func<TEntity, bool>> filter = null,
          Expression<Func<TEntity, TEntity>> keySelector = null,


        /// <summary>
        /// Get a collecion of the entity
        /// </summary>
        Func<IQueryable<TResult>, IOrderedQueryable<TResult>> orderBy = null,
        string includeProperties = "", int? page = null, int? pageSize = null);


        /// <summary>
        /// Deletes an entity
        /// </summary>
        void Delete(Guid id);

        /// <summary>
        /// Deletes an entity
        /// </summary>
        void Delete(TEntity entity);
    }
}