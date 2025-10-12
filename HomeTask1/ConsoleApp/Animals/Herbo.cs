namespace ConsoleApp.Animals
{
    public abstract class Herbo(string name, int food, int kindness) : Animal(name, food)
    {
        public int Kindness { get; private set; } = kindness;

        public bool CanBeInPettingZoo()
        {
            return Kindness > 5;
        }
    }
}