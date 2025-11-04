using ConsoleApp.Commands;
using ConsoleApp.Facades;
using ConsoleApp.Models;

namespace ConsoleApp.UI.SubMenus
{
    public class OperationMenu(OperationFacade operations, BankAccountFacade accounts, CategoryFacade categories)
    {
        private readonly OperationFacade _operations = operations;
        private readonly BankAccountFacade _accounts = accounts;
        private readonly CategoryFacade _categories = categories;

        public void Run()
        {
            Console.WriteLine("\n-- ОПЕРАЦИИ --");
            Console.WriteLine("1. Добавить операцию");
            Console.WriteLine("2. Удалить операцию");
            Console.WriteLine("3. Показать все операции");
            Console.WriteLine("0. Назад");
            Console.Write("Выбор: ");
            string? c = Console.ReadLine();

            switch (c)
            {
                case "1":
                    foreach (BankAccount a in _accounts.GetAll())
                    {
                        Console.WriteLine($"{a.Id} | {a.Name} ({a.Balance}₽)");
                    }

                    Console.Write("Введите ID счёта: ");
                    Guid accId = Guid.Parse(Console.ReadLine());

                    foreach (Category cat in _categories.GetAll())
                    {
                        Console.WriteLine($"{cat.Id} | {cat.Name} | {cat.Type}");
                    }

                    Console.Write("Введите ID категории: ");
                    Guid catId = Guid.Parse(Console.ReadLine());
                    Console.Write("Тип операции (i/e): ");
                    string? t = Console.ReadLine();
                    OperationType opType = t.ToLower() == "i" ? OperationType.Income : OperationType.Expense;
                    Console.Write("Сумма: ");
                    decimal amount = decimal.Parse(Console.ReadLine());
                    Console.Write("Описание (опционально): ");
                    string? desc = Console.ReadLine();

                    AddOperationCommand cmd = new(_operations, opType, accId, catId, amount, DateTime.Now, desc);
                    new CommandTimerDecorator(cmd).Execute();

                    Console.WriteLine("Операция добавлена.");
                    break;

                case "2":
                    Console.Write("Введите ID операции: ");
                    _operations.Delete(Guid.Parse(Console.ReadLine()));
                    Console.WriteLine("Удалено.");
                    break;

                case "3":
                    foreach (Operation o in _operations.GetAll())
                    {
                        Console.WriteLine($"{o.Id} | {o.Type} | {o.Amount}₽ | {o.Date:g} | {o.Description}");
                    }

                    break;
            }
        }
    }
}
