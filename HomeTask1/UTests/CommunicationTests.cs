using Xunit;
using ConsoleApp.Services;
using System.Collections.Generic;

namespace UTests
{
    public class CommunicationTests
    {
        [Fact]
        public void MainMenue()
        {
            var fake = new FakeConsole(["abc", "5", "2"]);
            var comm = new Communication(fake);

            int command = comm.MainMenue();

            Assert.Equal(2, command);
            Assert.Contains("Ошибка", string.Join("", fake.Outputs));
        }

        [Fact]
        public void AnimalsMenue()
        {
            Zoo zoo = new(new FakeVetClinic());
            FakeConsole fake = new(["Cat", null, "Wolf"]); // первый ввод неверный
            Communication comm = new(fake);

            string result = comm.AnimalsMenue(zoo);

            Assert.Equal("Wolf", result);
            Assert.Contains("Ошибка", string.Join("", fake.Outputs));
        }

        [Fact]
        public void ThingsMenue()
        {
            Zoo zoo = new(new FakeVetClinic());
            FakeConsole fake = new(["Wtf", null, "Computer"]);
            Communication comm = new(fake);

            string result = comm.ThingsMenue(zoo);

            Assert.Equal("Computer", result);
            Assert.Contains("Ошибка", string.Join("", fake.Outputs));
        }

        [Fact]
        public void GetAmountOfFood()
        {
            FakeConsole fake = new(["-5", "abc", "10"]);
            Communication comm = new(fake);

            int amount = comm.GetAmountOfFood();

            Assert.Equal(10, amount);
        }

        [Fact]
        public void GetKindness()
        {
            FakeConsole fake = new(["0", "wtf", "15", "8"]);
            Communication comm = new(fake);

            int kindness = comm.GetKindness();

            Assert.Equal(8, kindness);
        }

        [Fact]
        public void GetNumber()
        {
            FakeConsole fake = new(["-1", "wtf", "3"]);
            Communication comm = new(fake);

            int number = comm.GetNumber();

            Assert.Equal(3, number);
        }
    }
}