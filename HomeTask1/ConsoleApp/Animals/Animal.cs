using ConsoleApp.Interfaces;

namespace ConsoleApp.Animals
{
    public abstract class Animal(string name, int food) : IAlive, IInventory
    {
        public int Number { get; private set; } = 1;
        public int Food { get; protected set; } = food;
        public string Name { get; protected set; } = name;
        public bool IsHealthy { get; set; }
    }
}