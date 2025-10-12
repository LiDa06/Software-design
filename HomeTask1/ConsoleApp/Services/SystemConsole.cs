using ConsoleApp.Interfaces;

namespace ConsoleApp.Services
{
    public class SystemConsole : IConsole
    {
        public void WriteLine(string message) => Console.WriteLine(message);
        public void Write(string message) => Console.Write(message);
        public string? ReadLine() => Console.ReadLine();
    }
}