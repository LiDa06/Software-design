using Microsoft.Extensions.DependencyInjection;
using ConsoleApp.Interfaces;
using ConsoleApp.Alive;
using ConsoleApp.Inventory;
using ConsoleApp.Services;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {


            /*var services = new ServiceCollection();

            services.AddSingleton<IVetClinic, VetClinic>();
            services.AddSingleton<Zoo>();

            var provider = services.BuildServiceProvider();

            var zoo = provider.GetRequiredService<Zoo>(); 

            // --- Используем приложение ---
            zoo.AddAnimal(new Rabbit("Кролик", 2, 7));
            zoo.AddAnimal(new Tiger("Тигр", 10));
            zoo.AddThing(new Table(101));
            zoo.AddThing(new Computer(102));

            Console.WriteLine($"Всего еды в день: {zoo.TotalAmountOfFood()} кг");
            Console.WriteLine("\nКонтактный зоопарк:");
            foreach (var animal in zoo.PettingZooAnimals())
                Console.WriteLine($" - {animal.Name}");

            Console.WriteLine();
            zoo.Inventory();*/
        }
    }
}
