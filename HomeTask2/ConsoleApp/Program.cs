using ConsoleApp.Domain;
using ConsoleApp.Facades;
using ConsoleApp.ImportExportData;
using ConsoleApp.Models;
using ConsoleApp.Repositories;
using ConsoleApp.UI;
using ConsoleApp.UI.SubMenus;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main()
        {
            ServiceCollection services = new();

            //Domain
            _ = services.AddSingleton<Factory>();
            _ = services.AddSingleton<IRepository<BankAccount>>(p => new InMemoryRepository<BankAccount>(a => a.Id));
            _ = services.AddSingleton<IRepository<Category>>(p => new InMemoryRepository<Category>(a => a.Id));
            _ = services.AddSingleton<IRepository<Operation>>(p => new InMemoryRepository<Operation>(a => a.Id));

            //Fasades
            _ = services.AddSingleton<BankAccountFacade>();
            _ = services.AddSingleton<CategoryFacade>();
            _ = services.AddSingleton<OperationFacade>();
            _ = services.AddSingleton<AnalyticsFacade>();

            //Export
            _ = services.AddSingleton<JsonExportVisitor>();
            _ = services.AddSingleton<CsvExportVisitor>();

            // UI
            _ = services.AddSingleton<BankAccountMenu>();
            _ = services.AddSingleton<CategoryMenu>();
            _ = services.AddSingleton<OperationMenu>();
            _ = services.AddSingleton<AnalyticsMenu>();
            _ = services.AddSingleton<ImportExportMenu>();
            _ = services.AddSingleton<ConsoleMenu>();

            ServiceProvider sp = services.BuildServiceProvider();
            ConsoleMenu menu = sp.GetRequiredService<ConsoleMenu>();
            menu.Run();
        }
    }
}
