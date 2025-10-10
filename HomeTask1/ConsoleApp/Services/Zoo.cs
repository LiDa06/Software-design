using ConsoleApp.Alive;
using ConsoleApp.Inventory;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace ConsoleApp.Services
{
    public class Zoo(IVetClinic vetClinic)
    {
        private readonly IVetClinic _vetClinic = vetClinic;
        private readonly List<Animal> _animals = [];
        private readonly List<Thing> _things = [];
        private readonly List<string> _animalTypes = ["Monkey", "Rabbit", "Tiger", "Wolf"];
        private readonly List<string> _thingTypes = ["Table", "Computer"];

        public void AddAnimal(Animal animal)
        {
            if (_vetClinic.CheckHealth(animal))
            {
                _animals.Add(animal);
                Console.WriteLine("Животное добавлено в зоопарк!");
            }
            else
            {
                Console.WriteLine("Животное нездорово, невозможно добавить в зоопарк!");
            }
        }
        public void AddThing(Thing thing)
        {
            _things.Add(thing);
        }

        public int TotalAmountOfFood()
        {
            int amount = 0;
            foreach (Animal animal in _animals)
            {
                amount += animal.Food;
            }

            return amount;
        }

        public IEnumerable<Animal> PettingZooAnimals()
        {
            return _animals.OfType<Herbo>().Where(h => h.CanBeInPettingZoo());
        }

        public List<string> AnimalTypes()
        {
            return _animalTypes;
        }

        public List<string> ThingTypes()
        {
            return _thingTypes;
        }

        public void Inventory()
        {
            Console.WriteLine("Inventory");
            foreach (Thing thing in _things)
            {
                Console.WriteLine($"Thing: {thing.GetType().Name}, №{thing.Number}");
            }

            foreach (Animal animal in _animals)
            {
                Console.WriteLine($"Animal: {animal.GetType().Name} {animal.Name}");
            }
        }
    }
}