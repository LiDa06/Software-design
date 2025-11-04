using ConsoleApp.Facades;
using ConsoleApp.Models;
using System;

namespace ConsoleApp.UI.SubMenus
{
    public class AnalyticsMenu(AnalyticsFacade analytics, CategoryFacade categories)
    {
        private readonly AnalyticsFacade _analytics = analytics;
        private readonly CategoryFacade _categories = categories;

        public void Run()
        {
            Console.WriteLine("\n-- АНАЛИТИКА --");
            Console.Write("Введите дату начала (гггг-мм-дд): ");
            DateTime from;
            while (!DateTime.TryParse(Console.ReadLine(), out from)){
                Console.WriteLine("Некорректный формат даты");
                Console.Write("Введите дату начала (гггг-мм-дд): ");
            }

            Console.Write("Введите дату конца (гггг-мм-дд): ");
            DateTime to;
            while (!DateTime.TryParse(Console.ReadLine(), out to)){
                Console.WriteLine("Некорректный формат даты");
                Console.Write("Введите дату конца (гггг-мм-дд): ");
            }

            decimal net = _analytics.ComputeNetForPeriod(from, to);
            Console.WriteLine($"Разница доходов и расходов: {net}");

            IDictionary<Guid, decimal> grouped = _analytics.GroupByCategory(from, to, OperationType.Expense);
            Console.WriteLine("\nРасходы по категориям:");
            foreach (KeyValuePair<Guid, decimal> g in grouped)
            {
                Category cat = _categories.Get(g.Key);
                Console.WriteLine($"- {cat?.Name ?? "Безымянная категория"}: {g.Value}");
            }
        }
    }
}
