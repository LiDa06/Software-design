using ConsoleApp.Interfaces;

namespace ConsoleApp.Things
{
    public class Thing(int number) : IInventory
    {
        public int Number { get; } = number;
    }
}