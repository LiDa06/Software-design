using ConsoleApp.Alive;

namespace ConsoleApp.Services
{   
    public interface IVetClinic
    {
        bool CheckHealth(Animal animal);
    }
}