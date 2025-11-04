using ConsoleApp.Models;
using System.Collections.Generic;

namespace ConsoleApp.Models
{
    public class ExportedData
    {
        public List<BankAccount> Accounts { get; set; } = [];
        public List<Category> Categories { get; set; } = [];
        public List<Operation> Operations { get; set; } = [];
    }
}
