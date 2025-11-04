using ConsoleApp.Facades;
using ConsoleApp.ImportExportData;
using System;
using System.IO;
using System.Text;

namespace ConsoleApp.UI.SubMenus
{
    public class ImportExportMenu(JsonExportVisitor json, CsvExportVisitor csv, BankAccountFacade acc, CategoryFacade cat, OperationFacade op)
    {
        private readonly JsonExportVisitor _json = json;
        private readonly CsvExportVisitor _csv = csv;
        private readonly BankAccountFacade _acc = acc;
        private readonly CategoryFacade _cat = cat;
        private readonly OperationFacade _op = op;

        public void Run()
        {
            Console.WriteLine("\n-- ИМПОРТ / ЭКСПОРТ ДАННЫХ --");
            Console.WriteLine("1. Экспорт данных");
            Console.WriteLine("2. Импорт данных");
            Console.Write("Выбор: ");
            switch (Console.ReadLine())
            {
                case "1": Export(); break;
                //case "2": Import(); break;
                default: break;
            }
        }

        private void Export()
        {
            Console.Write("Формат (json/csv): ");
            string fmt = Console.ReadLine().ToLower();
            Console.Write("Вывести в консоль (c) или сохранить в файл (f)? ");
            string mode = Console.ReadLine().ToLower();

            IExportVisitor exporter = fmt == "json" ? _json : _csv;

            string result = "[" + 
                exporter.ExportAccounts(_acc.GetAll()) + "," +
                exporter.ExportCategories(_cat.GetAll()) + "," +
                exporter.ExportOperations(_op.GetAll()) + "]";

            if (mode == "f")
            {
                string dataDir = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "DataFiles");
                _ = Directory.CreateDirectory(dataDir);

                string fileName = $"export_{DateTime.Now:yyyyMMdd_HHmm}.{fmt}";
                string path = Path.Combine(dataDir, fileName);

                File.WriteAllText(path, result, Encoding.UTF8);
                Console.WriteLine($"Данные экспортированы в файл:\n{Path.GetFullPath(path)}");
            }
            else
            {
                Console.WriteLine("\n=== ЭКСПОРТ ===");
                Console.WriteLine(result);
            }
        }
    }
}
