using Xunit;
using ConsoleApp.Services;
using ConsoleApp.Animals;
using ConsoleApp.Things;
using Microsoft.Extensions.DependencyInjection;

namespace UTests
{
    public class CreatingTests
    {
        [Fact]
        public void CreateMonkey()
        {
            Monkey monkey = new("Monkey", 23, 10);
            Assert.NotNull(monkey);
        }
        [Fact]
        public void CreateRabbit()
        {
            Rabbit rabbit = new("Rabbit", 39, 1);
            Assert.NotNull(rabbit);
        }
        [Fact]
        public void CreateTiger()
        {
            Tiger tiger = new("Tiger", 3);
            Assert.NotNull(tiger);
        }
        [Fact]
        public void CreateWolf()
        {
            Wolf wolf = new("Wolf", 300);
            Assert.NotNull(wolf);
        }
        [Fact]
        public void CreateTable()
        {
            Table table = new(10);
            Assert.NotNull(table);
        }
        [Fact]
        public void CreateComputer()
        {
            Computer computer = new(101);
            Assert.NotNull(computer);
        }
        [Fact]
        public void CreateZoo()
        {
            ServiceCollection services = [];
            services.AddTransient<IVetClinic, VetClinic>();
            services.AddTransient<Zoo>();

            ServiceProvider provider = services.BuildServiceProvider();

            Zoo zoo = provider.GetService<Zoo>();

            Assert.NotNull(zoo);
        }
        [Fact]
        public void CreateVetClinic()
        {
            ServiceCollection services = [];
            services.AddTransient<IVetClinic, VetClinic>();
            ServiceProvider provider = services.BuildServiceProvider();

            IVetClinic clinic = provider.GetRequiredService<IVetClinic>();

            Assert.NotNull(clinic);
            Assert.IsType<VetClinic>(clinic);
        }
    }
}