using Xunit;
using ConsoleApp.Animals;
using ConsoleApp.Services;

namespace UTests
{
    public class VetClinicTests
    {
        [Fact]
        public void CheckHealth()
        {
            var vet = new VetClinic();
            var rabbit = new Rabbit("Bunny", 5, 8);

            bool result = vet.CheckHealth(rabbit);

            Assert.Equal(rabbit.IsHealthy, result);
        }
    }
}
