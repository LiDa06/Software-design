using Xunit;
using ConsoleApp.Services;
using ConsoleApp.Alive;

public class ZooTests
{
    [Fact]
    public void AddAnimal_ShouldIncreaseCount()
    {
        Zoo zoo = new(new VetClinic());
        zoo.AddAnimal(new Rabbit("ajfn", 1, 10));
        Assert.Single(zoo.PettingZooAnimals());
    }
}
