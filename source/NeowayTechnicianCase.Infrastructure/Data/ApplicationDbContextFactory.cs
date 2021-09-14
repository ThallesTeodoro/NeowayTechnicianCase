using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace NeowayTechnicianCase.Infrastructure.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public string ConnectionString { get; set; }

        /// <summary>
        /// Constructor method
        /// </summary>
        public ApplicationDbContextFactory()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Infrastructure.json")
                .Build();
            this.ConnectionString = configuration.GetConnectionString("ApplicationContext");
        }

        /// <summary>
        /// Create the DbContext
        /// </summary>
        /// <param name="args"></param>
        /// <returns>ApplicationDbContext</returns>
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseNpgsql(ConnectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}