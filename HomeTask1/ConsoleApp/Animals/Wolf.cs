namespace ConsoleApp.Animals
{
    public class Wolf(string name, int food) : Predator(name, food)
    {
        public override string ToString()
        {
            return $"Wolf {Name}";
        }
    }
}