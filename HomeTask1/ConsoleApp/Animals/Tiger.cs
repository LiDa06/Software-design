namespace ConsoleApp.Alive
{
    public class Tiger(string name, int food) : Predator(name, food)
    {
        public override string ToString()
        {
            return $"Tiger {Name}";
        }
    }
}