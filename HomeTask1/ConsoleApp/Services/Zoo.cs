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
        private readonly List<string> _herboTypes = ["Monkey", "Rabbit"];
        private readonly List<string> _predarorTypes = ["Tiger", "Wolf"];

        public List<string> AnimalTypes => _animalTypes;
        public List<string> ThingTypes => _thingTypes;
        public List<string> HerboTypes => _herboTypes;
        public List<string> PredatorTypes => _predarorTypes;

        public bool AddAnimal(Animal animal)
        {
            if (_vetClinic.CheckHealth(animal))
            {
                _animals.Add(animal);
                return true;
            }

            return false;
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
    }
}