using ConsoleApp.Interfaces;
using ConsoleApp.Alive;
using ConsoleApp.Inventory;

namespace ConsoleApp.Services
{
    public class Commands(IConsole console, Communication communication, Zoo zoo)
    {
        private readonly IConsole _console = console;
        private readonly Communication _communication = communication;
        private readonly Zoo _zoo = zoo;

        public void Run()
        {
            bool run = true;

            while (run)
            {
                int command = _communication.MainMenue();

                switch (command)
                {
                    case 1:
                        Command1();
                        break;
                    case 2:
                        Command2();
                        break;
                    case 3:
                        Command3();
                        break;
                    case 4:
                        run = false;
                        break;
                }
            }
        }

        public void Command1()
        {
            string animalType = _communication.AnimalsMenue(_zoo);
            string animalName = _communication.GetName();
            int food = _communication.GetAmountOfFood();
            bool isAdded = false;
            if (_zoo.HerboTypes.Contains(animalType))
            {
                int kindness = _communication.GetKindness();
                switch (animalType)
                {
                    case "Monkey": isAdded = _zoo.AddAnimal(new Monkey(animalName, food, kindness)); break;
                    case "Rabbit": isAdded = _zoo.AddAnimal(new Rabbit(animalName, food, kindness)); break;
                }
            }
            else
            {
                switch (animalType)
                {
                    case "Tiger": isAdded = _zoo.AddAnimal(new Tiger(animalName, food)); break;
                    case "Wolf": isAdded = _zoo.AddAnimal(new Wolf(animalName, food)); break;
                }
            }

            if (isAdded)
            {
                _console.WriteLine($"{animalType} {animalName} успешно добавлен!");
            }
            else
            {
                _console.WriteLine($"{animalType} {animalName} болен, невозможно добавить!");
            }
        }

        public void Command2()
        {
            string thingType = _communication.ThingsMenue(_zoo);
            int number = _communication.GetNumber();
            switch (thingType)
            {
                case "Computer": _zoo.AddThing(new Computer(number)); break;
                case "Table": _zoo.AddThing(new Table(number)); break;
            }
        }

        public void Command3()
        {
            _console.WriteLine("Животные для контактного зоопарка: ");
            foreach (var animal in _zoo.PettingZooAnimals())
            {
                _console.WriteLine($" * {animal.GetType()} {animal.Name}");
            }
        }
    }
}
