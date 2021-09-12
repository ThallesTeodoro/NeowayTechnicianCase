using System;
using Microsoft.Extensions.DependencyInjection;

namespace NeowayTechnicianCase.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Press any key to start the application.");
            Console.ReadKey();
            Console.WriteLine("Hello World!");

            IServiceCollection services = new ServiceCollection();

            Startup startup = new Startup();
            startup.ConfigureServices(services);

            Console.WriteLine("Press any key to quit.");
            Console.ReadKey();
        }
    }
}
