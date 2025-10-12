using System.ComponentModel.DataAnnotations;
using ConsoleApp.Interfaces;

namespace ConsoleApp.Services
{
    public class Communication(IConsole console)
    {
        private readonly IConsole _console = console;

        public int MainMenue()
        {
            _console.WriteLine("============= Меню =============");
            _console.WriteLine("1. Добавить животное");
            _console.WriteLine("2. Добавить вещь");
            _console.WriteLine("3. Показать животных, пригодных для контактного зоопарка");
            _console.WriteLine("4. Выйти");
            _console.Write("Выберите пункт: ");

            int command;
            while (!int.TryParse(_console.ReadLine(), out command) || 1 > command || command > 4)
            {
                _console.WriteLine("Ошибка! Повторите попытку.");
                _console.Write("Выберите пункт: ");
            }

            return command;
        }
        public string AnimalsMenue(Zoo zoo)
        {
            _console.WriteLine("Выберите животное:");
            foreach (string type in zoo.AnimalTypes)
            {
                _console.WriteLine($" * {type}");
            }

            _console.Write("Ваш выбор: ");
            string? animal = _console.ReadLine();

            while (string.IsNullOrWhiteSpace(animal) || !zoo.AnimalTypes.Contains(animal))
            {
                _console.WriteLine("Ошибка! Введите одно из предложенных значений.");
                _console.Write("Ваш выбор: ");
                animal = _console.ReadLine();
            }

            return animal;
        }

        public string ThingsMenue(Zoo zoo)
        {
            _console.WriteLine("Выберите вещь:");
            foreach (string type in zoo.ThingTypes)
            {
                _console.WriteLine($" * {type}");
            }

            _console.Write("Ваш выбор: ");
            string? thing = _console.ReadLine();

            while (string.IsNullOrWhiteSpace(thing) || !zoo.ThingTypes.Contains(thing))
            {
                _console.WriteLine("Ошибка! Введите одно из предложенных значений.");
                _console.Write("Ваш выбор: ");
                thing = _console.ReadLine();
            }

            return thing;
        }

        public string GetName()
        {
            _console.Write("Введите имя животного: ");
            return _console.ReadLine() ?? string.Empty;
        }

        public int GetAmountOfFood()
        {
            _console.Write("Введите количество еды: ");
            int amount;

            while (!int.TryParse(_console.ReadLine(), out amount) || amount < 0)
            {
                _console.WriteLine("Ошибка! Введите целое положительное число:");
                _console.Write("Введите количество еды: ");
            }

            return amount;
        }

        public int GetKindness()
        {
            _console.Write("Введите уровень доброты (1–10): ");
            int value;
            while (!int.TryParse(_console.ReadLine(), out value) || value < 1 || value > 10)
            {
                _console.WriteLine("Ошибка! Введите число от 1 до 10:");
                _console.Write("Введите уровень доброты (1–10): ");
            }
            return value;
        }

        public int GetNumber()
        {
            _console.Write("Введите количество: ");
            int number;
            while (!int.TryParse(_console.ReadLine(), out number) || number <= 0)
            {
                _console.WriteLine("Ошибка! Введите корректное колличество (целое положительное число):");
                _console.Write("Введите количество: ");
            }
            return number;
        }
    }
}