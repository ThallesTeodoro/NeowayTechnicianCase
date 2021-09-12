using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NeowayTechnicianCase.Core.Interfaces.Repositories;
using NeowayTechnicianCase.Infrastructure.Data;
using NeowayTechnicianCase.Infrastructure.Repositories;

namespace NeowayTechnicianCase.ConsoleApplication
{
    public class Startup
    {
        IConfigurationRoot Configuration { get; }

        /// <summary>
        /// Constructor method
        /// </summary>
        public Startup()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        /// <summary>
        /// Configure application services
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfigurationRoot>(Configuration);

            services.AddDbContext<ApplicationDbContext>(options => options
                .UseNpgsql(Configuration.GetConnectionString("ApplicationContext")));

            var sp = services.BuildServiceProvider();

            using (var scope = sp.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<ApplicationDbContext>();

                db.Database.Migrate();
                db.Database.EnsureDeleted();
            }

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IPurchaseRepository, PurchaseRepository>();
            services.AddTransient<IStoreRepository, StoreRepository>();
        }
    }
}