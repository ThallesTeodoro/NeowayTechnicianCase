using NeowayTechnicianCase.Core.Interfaces.Repositories;
using NeowayTechnicianCase.Infrastructure.Data;

namespace NeowayTechnicianCase.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Commit database transaction
        /// </summary>
        public void Commit()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Rollback database transection
        /// </summary>
        public void Rollback()
        {
            _context.Dispose();
        }
    }
}