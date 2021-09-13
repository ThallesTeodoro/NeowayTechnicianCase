using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NeowayTechnicianCase.Core.Interfaces.Services;
using NeowayTechnicianCase.Core.Interfaces.Validations;
using NeowayTechnicianCase.Infrastructure.Data;
using NeowayTechnicianCase.Infrastructure.Validations;

namespace NeowayTechnicianCase.ConsoleApplication
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Console.Clear();
            Console.WriteLine("Press any key to start the application.");
            // Console.ReadKey();
            Console.WriteLine("\nRunning the service...");

            IServiceCollection services = new ServiceCollection();

            Startup startup = new Startup();
            startup.ConfigureServices(services);

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            IFileReading fileReading = serviceProvider.GetService<IFileReading>();
            IFilePersisting filePersisting = serviceProvider.GetService<IFilePersisting>();
            string path = Directory.GetCurrentDirectory() + "/base_teste.txt";

            DateTime init = DateTime.Now;

            List<string[]> data = await fileReading.ReadFile(path, new char[] { ' ' }, 1);
            await filePersisting.Persist(data);
            // await filePersisting.ReadPersisting(path, new char[] { ' ' }, 1);

            DateTime final = DateTime.Now;

            Console.WriteLine("\n--------------------------------------------\n");
            Console.WriteLine("Runtime: " + (final - init).TotalSeconds);

            var sp = services.BuildServiceProvider();

            using (var scope = sp.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<ApplicationDbContext>();

                Console.WriteLine("Database rows affected(Purchase): " + db.Purchases.Count());
            }

            Console.WriteLine("\n\nPress any key to quit.");
            // Console.ReadKey();
        }
    }
}
