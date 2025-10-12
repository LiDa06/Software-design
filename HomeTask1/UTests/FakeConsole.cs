using System.Collections.Generic;
using ConsoleApp.Interfaces;

namespace UTests
{
    public class FakeConsole(IEnumerable<string> inputs) : IConsole
    {
        private readonly Queue<string> _inputs = new(inputs);
        public List<string> Outputs { get; } = [];

        public void WriteLine(string message) => Outputs.Add(message + "\n");
        public void Write(string message) => Outputs.Add(message);
        public string ReadLine()
        {
            return _inputs.Count > 0 ? _inputs.Dequeue() : string.Empty;
        }
    }
}
