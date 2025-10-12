using Microsoft.Extensions.DependencyInjection;
using ConsoleApp.Interfaces;
using ConsoleApp.Services;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main()
        {
            ServiceCollection services = new();

            services.AddTransient<IConsole, SystemConsole>();
            services.AddTransient<Communication>();
            services.AddTransient<Zoo>();
            services.AddTransient<Commands>();

            ServiceProvider provider = services.BuildServiceProvider();

            var commands = provider.GetRequiredService<Commands>();
            commands.Run();
        }
    }
}
