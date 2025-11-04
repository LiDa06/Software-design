using System.Diagnostics;

namespace ConsoleApp.Commands
{
    public class CommandTimerDecorator(ICommand inner) : ICommand
    {
        private readonly ICommand _inner = inner;

        public void Execute()
        {
            DateTime start = DateTime.Now;
            _inner.Execute();
            TimeSpan duration = DateTime.Now - start;
            Console.WriteLine($"Выполнено за {duration.TotalMilliseconds} мс");
        }
    }
}
