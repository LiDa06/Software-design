using ConsoleApp.Facades;
using ConsoleApp.Models;
using System;

namespace ConsoleApp.UI.SubMenus
{
    public class CategoryMenu(CategoryFacade categories)
    {
        private readonly CategoryFacade _categories = categories;

        public void Run()
        {
            Console.WriteLine("\n-- КАТЕГОРИИ --");
            Console.WriteLine("1. Создать категорию");
            Console.WriteLine("2. Удалить категорию");
            Console.WriteLine("3. Показать все категории");
            Console.WriteLine("0. Назад");
            Console.Write("Выбор: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Название категории: ");
                    string? name = Console.ReadLine();
                    Console.Write("Тип (i - доход, e - расход): ");
                    string? t = Console.ReadLine();
                    while (t == null || (t.ToLower() is not "i" and not "e"))
                    {
                        Console.WriteLine("Некорректный тип");
                        Console.Write("Тип (i - доход, e - расход): ");
                        t = Console.ReadLine();
                    }
                    CategoryType type = t.Equals("i") ? CategoryType.Income : CategoryType.Expense;

                    Category cat = _categories.CreateCategory(type, name);
                    Console.WriteLine($"Категория создана: {cat.Name} ({cat.Type})");
                    break;

                case "2":
                    Console.Write("ID категории: ");
                    _categories.Delete(Guid.Parse(Console.ReadLine()));
                    Console.WriteLine("Удалена.");
                    break;

                case "3":
                    foreach (Category c in _categories.GetAll()) { 
                        Console.WriteLine($"{c.Id} | {c.Name} | {c.Type}");
                    }
                    break;
            }
        }
    }
}
