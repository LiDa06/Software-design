using System;
using ConsoleApp.Facades;
using ConsoleApp.Models;

namespace ConsoleApp.UI.SubMenus
{
    public class BankAccountMenu(BankAccountFacade accounts)
    {
        private readonly BankAccountFacade _accounts = accounts;

        public void Run()
        {
            Console.WriteLine("\n-- УПРАВЛЕНИЕ СЧЕТАМИ --");
            Console.WriteLine("1. Создать счёт");
            Console.WriteLine("2. Переименовать счёт");
            Console.WriteLine("3. Удалить счёт");
            Console.WriteLine("4. Показать все счета");
            Console.WriteLine("0. Назад");
            Console.Write("Выбор: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Название счёта: ");
                    string? name = Console.ReadLine();
                    Console.Write("Начальный баланс: ");
                    _ = decimal.TryParse(Console.ReadLine(), out decimal bal);
                    BankAccount acc = _accounts.CreateAccount(name, bal);
                    Console.WriteLine($"Счёт создан: {acc.Name} ({acc.Balance})");
                    break;

                case "2":
                    Console.Write("ID счёта: ");
                    _ = Guid.TryParse(Console.ReadLine(), out Guid id);
                    Console.Write("Новое имя: ");
                    _accounts.Rename(id, Console.ReadLine());
                    Console.WriteLine("Имя обновлено.");
                    break;

                case "3":
                    Console.Write("ID счёта: ");
                    _accounts.Delete(Guid.Parse(Console.ReadLine()));
                    Console.WriteLine("Счёт удалён.");
                    break;

                case "4":
                    Console.WriteLine("-- Все счета --");
                    foreach (BankAccount a in _accounts.GetAll())
                    {
                        Console.WriteLine($"{a.Id} | {a.Name} | Баланс: {a.Balance}");
                    }

                    break;
            }
        }
    }
}
