using ConsoleApp.Animals;

namespace ConsoleApp.Services
{
    public class VetClinic : IVetClinic
    {
        private readonly Random _random = new();

        public bool CheckHealth(Animal animal)
        {
            bool healthy = _random.Next(2) == 1;
            animal.IsHealthy = healthy;
            return healthy;
        }
    }
}