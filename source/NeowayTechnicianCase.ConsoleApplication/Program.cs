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
            Console.Clear();
            Console.WriteLine("Press any key to start the application.");
            Console.ReadKey();

            Console.WriteLine("\nPreparing services...");

            IServiceCollection services = new ServiceCollection();

            Startup startup = new Startup();
            startup.ConfigureServices(services);

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            IFileReading fileReading = serviceProvider.GetService<IFileReading>();
            IFilePersisting filePersisting = serviceProvider.GetService<IFilePersisting>();
            string path = Directory.GetCurrentDirectory() + "/base_teste.txt";

            DateTime init = DateTime.Now;

            Console.WriteLine("\nProcess started at " + init.ToString() + ". Running the File Reading and Persisting service...");

            List<string[]> data = await fileReading.ReadFile(path,  @"[ ]{1,}", 1);
            await filePersisting.Persist(data);

            DateTime final = DateTime.Now;

            Console.WriteLine("\nFinished at " + final.ToString() + "\n");
            Console.WriteLine("\n--------------------------------------------\n");
            Console.WriteLine("Runtime: " + (final - init).TotalSeconds + " s");

            var sp = services.BuildServiceProvider();

            using (var scope = sp.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<ApplicationDbContext>();

                Console.WriteLine("Database rows affected(Purchase): " + db.Purchases.Count() + "\n\n");
            }
        }
    }
}
