namespace ConsoleApp.Animals
{
    public class Monkey(string name, int food, int kindness) : Herbo(name, food, kindness)
    {
        public override string ToString()
        {
            return $"Monkey {Name}";
        }
    }
}