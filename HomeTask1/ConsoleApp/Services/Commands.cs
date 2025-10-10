using ConsoleApp.Alive;
using ConsoleApp.Inventory;

namespace ConsoleApp.Services
{
    public static class Commands
    {
        public static void Command1(ref Zoo zoo)
        {
            string animalType = Communication.AnimalsMenue(ref zoo);
            switch (animalType)
            {
                case "Monkey":
                    {
                        zoo.AddAnimal(new Monkey(Communication.GetName(), Communication.GetAmountOfFood(), Communication.GetKindness()));
                        break;
                    }
                case "Rabbit":
                    {
                        zoo.AddAnimal(new Rabbit(Communication.GetName(), Communication.GetAmountOfFood(), Communication.GetKindness()));
                        break;
                    }
                case "Tiger":
                    {
                        zoo.AddAnimal(new Tiger(Communication.GetName(), Communication.GetAmountOfFood()));
                        break;
                    }
                case "Wolf":
                    {
                        zoo.AddAnimal(new Wolf(Communication.GetName(), Communication.GetAmountOfFood()));
                        break;
                    }
                default: break;
            }
        }

        public static void Command2(ref Zoo zoo)
        {
            string thingType = Communication.ThingsMenue(ref zoo);
            switch (thingType)
            {
                case "Computer":
                    {
                        zoo.AddThing(new Computer(Communication.GetNumber()));
                        break;
                    }
                case "Table":
                    {
                        zoo.AddThing(new Table(Communication.GetNumber()));
                        break;
                    }
                default: break;
            }
        }
    }
}