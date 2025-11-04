using System;
using System.Threading.Tasks;
using ConsoleApp.UI.SubMenus;

namespace ConsoleApp.UI
{
    public class ConsoleMenu(BankAccountMenu accounts, CategoryMenu categories, OperationMenu operations,
                             AnalyticsMenu analytics, ImportExportMenu importExport)
    {
        private readonly BankAccountMenu _bankAccountMenu = accounts;
        private readonly CategoryMenu _categoryMenu = categories;
        private readonly OperationMenu _operationMenu = operations;
        private readonly AnalyticsMenu _analyticsMenu = analytics;
        private readonly ImportExportMenu _importExportMenu = importExport;

        public void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Добро пожаловать! ===");

            bool running = true;
            while (running)
            {
                Console.WriteLine("\n------ ГЛАВНОЕ МЕНЮ ------");
                Console.WriteLine("1. Счета");
                Console.WriteLine("2. Категории");
                Console.WriteLine("3. Операции");
                Console.WriteLine("4. Аналитика");
                Console.WriteLine("5. Импорт / Экспорт");
                Console.WriteLine("0. Выход");
                Console.Write("Выбор: ");

                switch (Console.ReadLine())
                {
                    case "1": _bankAccountMenu.Run(); break;
                    case "2": _categoryMenu.Run(); break;
                    case "3": _operationMenu.Run(); break;
                    case "4": _analyticsMenu.Run(); break;
                    case "5": _importExportMenu.Run(); break;
                    case "0": running = false; break;
                    default: Console.WriteLine("Неверный выбор."); break;
                }
            }
        }
    }
}
