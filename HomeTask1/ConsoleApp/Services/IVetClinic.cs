using ConsoleApp.Animals;

namespace ConsoleApp.Services
{   
    public interface IVetClinic
    {
        bool CheckHealth(Animal animal);
    }
}