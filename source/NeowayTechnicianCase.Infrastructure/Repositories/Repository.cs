using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NeowayTechnicianCase.Core.Interfaces.Repositories;
using NeowayTechnicianCase.Infrastructure.Data;

namespace NeowayTechnicianCase.Infrastructure.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _dbContext;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="dbContext"></param>
        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Add new entity
        /// </summary>
        /// <param name="entity">Entity instance</param>
        public virtual async Task AddAsync(TEntity entity)
        {
            await _dbContext.AddAsync(entity);
        }

        /// <summary>
        /// Add many entitites
        /// </summary>
        /// <param name="entities">Entities list</param>
        public virtual async Task AddManyAsync(List<TEntity> entities)
        {
            await _dbContext.AddRangeAsync(entities);
        }

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>Entity instance</returns>
        public virtual async Task<TEntity> FindByIdAsync(Guid id)
        {
            return await _dbContext
                .Set<TEntity>()
                .FindAsync(id);
        }

        /// <summary>
        /// Update an entity
        /// </summary>
        /// <param name="entity">Entity instance</param>
        public virtual void Update(TEntity entity)
        {
            _dbContext
                .Set<TEntity>()
                .Update(entity);
        }

        /// <summary>
        /// Remove entity
        /// </summary>
        /// <param name="entity">Entity instance</param>
        public virtual void Remove(TEntity entity)
        {
            _dbContext
                .Set<TEntity>()
                .Remove(entity);
        }
    }
}
