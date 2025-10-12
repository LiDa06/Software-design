using ConsoleApp.Interfaces;

namespace ConsoleApp.Inventory
{
    public class Thing(int number) : IInventory
    {
        public int Number { get; } = number;
    }
}