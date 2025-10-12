namespace ConsoleApp.Animals
{
    public class Tiger(string name, int food) : Predator(name, food)
    {
        public override string ToString()
        {
            return $"Tiger {Name}";
        }
    }
}