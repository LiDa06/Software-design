using ConsoleApp.Models;
using System.Text;
using System.Text.Json;

namespace ConsoleApp.ImportExportData
{
    public interface IExportVisitor
    {
        string ExportAccounts(IEnumerable<BankAccount> accounts);
        string ExportCategories(IEnumerable<Category> categories);
        string ExportOperations(IEnumerable<Operation> operations);
    }

    public class JsonExportVisitor : IExportVisitor
    {
        public string ExportAccounts(IEnumerable<BankAccount> accounts)
        {
            return JsonSerializer.Serialize(accounts);
        }

        public string ExportCategories(IEnumerable<Category> categories)
        {
            return JsonSerializer.Serialize(categories);
        }

        public string ExportOperations(IEnumerable<Operation> operations)
        {
            return JsonSerializer.Serialize(operations);
        }
    }

    public class CsvExportVisitor : IExportVisitor
    {
        public string ExportAccounts(IEnumerable<BankAccount> accounts)
        {
            StringBuilder sb = new();
            _ = sb.AppendLine("Id,Name,Balance");
            foreach (BankAccount a in accounts)
            {
                _ = sb.AppendLine($"{a.Id},{Escape(a.Name)},{a.Balance}");
            }
            return sb.ToString();
        }

        public string ExportCategories(IEnumerable<Category> categories)
        {
            StringBuilder sb = new();
            _ = sb.AppendLine("Id,Type,Name");
            foreach (Category c in categories)
            {
                _ = sb.AppendLine($"{c.Id},{c.Type},{Escape(c.Name)}");
            }
            return sb.ToString();
        }

        public string ExportOperations(IEnumerable<Operation> operations)
        {
            StringBuilder sb = new();
            _ = sb.AppendLine("Id,Type,BankAccountId,CategoryId,Amount,Date,Description");
            foreach (Operation o in operations)
            {
                _ = sb.AppendLine($"{o.Id},{o.Type},{o.BankAccountId},{o.CategoryId},{o.Amount},{o.Date:o},{Escape(o.Description)}");
            }
            return sb.ToString();
        }

        private static string Escape(string s)
        {
            return s?.Replace(",", ";") ?? "";
        }
    }
}
