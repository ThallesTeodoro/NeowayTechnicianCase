using Microsoft.EntityFrameworkCore;
using NeowayTechnicianCase.Core.Entities;

namespace NeowayTechnicianCase.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Store> Stores { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
        }
    }
}