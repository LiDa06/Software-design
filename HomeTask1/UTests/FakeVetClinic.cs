using ConsoleApp.Animals;
using ConsoleApp.Services;

namespace UTests
{
    public class FakeVetClinic(bool Healthy = true) : IVetClinic
    {
        private readonly bool _Healthy = Healthy;

        public bool CheckHealth(Animal animal)
        {
            animal.IsHealthy = _Healthy;
            return _Healthy;
        }
    }
}
