using Microsoft.Extensions.DependencyInjection;
using ConsoleApp.Interfaces;
using ConsoleApp.Services;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main()
        {
            var services = new ServiceCollection();

            services.AddTransient<IConsole, SystemConsole>();
            services.AddTransient<IVetClinic, VetClinic>();
            services.AddTransient<Zoo>();
            services.AddTransient<Communication>();
            services.AddTransient<Commands>();

            var provider = services.BuildServiceProvider();

            var commands = provider.GetRequiredService<Commands>();
            commands.Run();
        }
    }
}
