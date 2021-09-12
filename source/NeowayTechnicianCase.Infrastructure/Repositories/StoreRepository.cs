using NeowayTechnicianCase.Core.Entities;
using NeowayTechnicianCase.Core.Interfaces.Repositories;
using NeowayTechnicianCase.Infrastructure.Data;

namespace NeowayTechnicianCase.Infrastructure.Repositories
{
    public class StoreRepository : Repository<Store>, IStoreRepository
    {
        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="dbContext"></param>
        public StoreRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
