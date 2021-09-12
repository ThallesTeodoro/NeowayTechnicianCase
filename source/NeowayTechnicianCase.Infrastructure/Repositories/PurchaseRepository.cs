using NeowayTechnicianCase.Core.Entities;
using NeowayTechnicianCase.Core.Interfaces.Repositories;
using NeowayTechnicianCase.Infrastructure.Data;

namespace NeowayTechnicianCase.Infrastructure.Repositories
{
    public class PurchaseRepository : Repository<Purchase>, IPurchaseRepository
    {
        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="dbContext"></param>
        public PurchaseRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
