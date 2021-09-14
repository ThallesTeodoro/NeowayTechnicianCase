using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NeowayTechnicianCase.Core.Interfaces.Repositories;
using NeowayTechnicianCase.Core.Interfaces.Services;
using NeowayTechnicianCase.Infrastructure.Data;
using NeowayTechnicianCase.Infrastructure.Repositories;
using NeowayTechnicianCase.Infrastructure.Services;

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

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IPurchaseRepository, PurchaseRepository>();
            services.AddTransient<IStoreRepository, StoreRepository>();

            services.AddScoped<IFileReading, FileReading>();
            services.AddScoped<IFilePersisting, FilePersisting>();

            var sp = services.BuildServiceProvider();

            using (var scope = sp.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<ApplicationDbContext>();

                db.Purchases.RemoveRange(db.Purchases);
                db.Stores.RemoveRange(db.Stores);
                db.SaveChanges();
            }
        }
    }
}