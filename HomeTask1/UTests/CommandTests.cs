using Xunit;
using ConsoleApp.Services;
using System.Collections.Generic;

namespace UTests
{
    public class CommandsTests
    {
        [Fact]
        public void Command1_HealthyAnimal()
        {
            FakeConsole fakeConsole = new(["Monkey", "Monkey", "5", "8"]);

            Zoo zoo = new(new FakeVetClinic(true));
            Communication comm = new(fakeConsole);
            Commands commands = new(fakeConsole, comm, zoo);

            commands.Command1();

            int number = zoo.NumberOfAnimals();
            Assert.Equal(1, number);
        }

        [Fact]
        public void Command1_SickAnimal()
        {
            FakeConsole fakeConsole = new(["Tiger", "Tiger", "10"]);

            Zoo zoo = new(new FakeVetClinic(false));
            Communication comm = new(fakeConsole);
            Commands commands = new(fakeConsole, comm, zoo);

            commands.Command1();

            int number = zoo.NumberOfAnimals();
            Assert.Equal(0, number);
        }

        [Fact]
        public void Comman1_AddAllAnimals()
        {
            FakeConsole fakeConsole = new(["Tiger", "Tiger", "10",
                                           "Wolf", "Wolf", "1",
                                           "Monkey", "Monkey", "11", "3",
                                           "Rabbit", "Rabbit", "20", "10"]);

            Zoo zoo = new(new FakeVetClinic(true));
            Communication comm = new(fakeConsole);
            Commands commands = new(fakeConsole, comm, zoo);

            for (int i = 0; i < 4; ++i)
            {
                commands.Command1();
            }

            int number = zoo.NumberOfAnimals();
            Assert.Equal(4, number);
        }

        [Fact]
        public void Command2()
        {
            FakeConsole fakeConsole = new(["Table", "3", "Computer", "10"]);

            Zoo zoo = new(new FakeVetClinic(true));
            Communication comm = new(fakeConsole);
            Commands commands = new(fakeConsole, comm, zoo);

            commands.Command2();
            commands.Command2();

            int number = zoo.NumberOfThings();
            Assert.Equal(13, number);
        }

        [Fact]
        public void Command3()
        {
            FakeConsole fakeConsole = new([]);
            Zoo zoo = new(new FakeVetClinic(true));
            Communication comm = new(fakeConsole);
            Commands commands = new(fakeConsole, comm, zoo);

            zoo.AddAnimal(new ConsoleApp.Animals.Rabbit("Rabbit", 5, 8));
            zoo.AddAnimal(new ConsoleApp.Animals.Wolf("Wolf", 2));

            commands.Command3();

            Assert.Contains("Rabbit", string.Join("", fakeConsole.Outputs));
        }
    }
}