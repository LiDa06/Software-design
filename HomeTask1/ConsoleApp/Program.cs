using Microsoft.Extensions.DependencyInjection;
using ConsoleApp.Interfaces;
using ConsoleApp.Alive;
using ConsoleApp.Inventory;
using ConsoleApp.Services;
using System.Collections;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceCollection services = [];

            services.AddTransient<IVetClinic, VetClinic>();
            services.AddTransient<Zoo>();

            ServiceProvider provider = services.BuildServiceProvider();

            Zoo zoo = provider.GetRequiredService<Zoo>();

            Console.WriteLine("Добро пожаловать в приложение!");
            bool stopPoint = true;
            while (stopPoint)
            {
                int command = Communication.MainMenue();
                switch (command)
                {
                    case 1: Commands.Command1(ref zoo); break;
                    case 2: Commands.Command2(ref zoo); break;
                    case 3: zoo.TotalAmountOfFood(); break;
                    case 4: zoo.PettingZooAnimals(); break;
                    case 5: zoo.Inventory(); break;
                    default: stopPoint = false; break;
                }
            }
        }
    }
}
