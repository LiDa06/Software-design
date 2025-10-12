using Xunit;
using ConsoleApp.Animals;
using ConsoleApp.Services;
using System.Linq;

namespace UTests
{
    public class ZooTests
    {
        [Fact]
        public void AddHealtyAnimal()
        {
            var zoo = new Zoo(new FakeVetClinic(true));
            var rabbit = new Rabbit("Bunny", 5, 8);

            bool added = zoo.AddAnimal(rabbit);

            Assert.True(added);
        }
        [Fact]
        public void TotalAmountOfFood()
        {
            var zoo = new Zoo(new FakeVetClinic(true));
            var tiger = new Tiger("ShereKhan", 10);
            var rabbit = new Rabbit("Fluffy", 5, 8);

            zoo.AddAnimal(tiger);
            zoo.AddAnimal(rabbit);

            int amount = zoo.TotalAmountOfFood();

            Assert.Equal(15, amount);
        }

        [Fact]
        public void AddSickAnimal()
        {
            var zoo = new Zoo(new FakeVetClinic(false));
            var tiger = new Tiger("ShereKhan", 10);

            bool added = zoo.AddAnimal(tiger);

            Assert.False(added);
        }

        [Fact]
        public void PettingZooAnimals()
        {
            var zoo = new Zoo(new FakeVetClinic(true));
            var rabbit = new Rabbit("Bunny", 5, 9);
            var tiger = new Tiger("ShereKhan", 5);
            var monkey = new Monkey("Monkey", 5, 1);

            zoo.AddAnimal(rabbit);
            zoo.AddAnimal(tiger);
            zoo.AddAnimal(monkey);

            var result = zoo.PettingZooAnimals().ToList();

            Assert.Single(result);
            Assert.Equal("Bunny", result.First().Name);
        }
    }
}
