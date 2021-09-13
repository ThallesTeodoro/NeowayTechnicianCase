using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NeowayTechnicianCase.Core.Interfaces.Repositories;
using NeowayTechnicianCase.Core.Interfaces.Services;
using NeowayTechnicianCase.Infrastructure.Data;
using NeowayTechnicianCase.Infrastructure.Repositories;
using NeowayTechnicianCase.Infrastructure.Services;

namespace NeowayTechnicianCase.IntegrationTests
{
    public class IntegrationTestBase
    {
        protected IServiceProvider serviceProvider { get; set; }

        /// <summary>
        /// Constructor method
        /// </summary>
        protected IntegrationTestBase()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddDbContextPool<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("TestDb" + this.GetType().Name));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IPurchaseRepository, PurchaseRepository>();
            services.AddTransient<IStoreRepository, StoreRepository>();

            services.AddScoped<IFileReading, FileReading>();
            services.AddScoped<IFilePersisting, FilePersisting>();

            serviceProvider = services.BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<ApplicationDbContext>();

                db.Database.EnsureDeleted();
            }
        }
    }
}