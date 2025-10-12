namespace ConsoleApp.Alive
{
    public class Rabbit(string name, int food, int kindness) : Herbo(name, food, kindness)
    {
        public override string ToString()
        {
            return $"Rabbit {Name}";
        }
    }
}