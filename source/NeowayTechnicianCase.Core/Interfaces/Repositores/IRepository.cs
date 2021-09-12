using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeowayTechnicianCase.Core.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Add new entity
        /// </summary>
        /// <param name="entity">Entity instance</param>
        Task AddAsync(TEntity entity);

        /// <summary>
        /// Add many entitites
        /// </summary>
        /// <param name="entities">Entities list</param>
        Task AddManyAsync(List<TEntity> entities);

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>Entity instance</returns>
        Task<TEntity> FindByIdAsync(Guid id);

        /// <summary>
        /// Update an entity
        /// </summary>
        /// <param name="entity">Entity instance</param>
        void Update(TEntity entity);

        /// <summary>
        /// Remove entity
        /// </summary>
        /// <param name="entity">Entity instance</param>
        void Remove(TEntity entity);
    }
}
