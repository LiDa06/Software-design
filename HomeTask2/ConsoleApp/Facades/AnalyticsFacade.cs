using ConsoleApp.Models;
using ConsoleApp.Repositories;

namespace ConsoleApp.Facades
{
    public class AnalyticsFacade(IRepository<Operation> operations, IRepository<Category> categories)
    {
        private readonly IRepository<Operation> _operations = operations;
        private readonly IRepository<Category> _categories = categories;

        public decimal ComputeNetForPeriod(DateTime from, DateTime to)
        {
            IEnumerable<Operation> ops = _operations.GetAll().Where(o => o.Date.Date >= from.Date && o.Date.Date <= to.Date);
            decimal income = ops.Where(o => o.Type == OperationType.Income).Sum(o => o.Amount);
            decimal expense = ops.Where(o => o.Type == OperationType.Expense).Sum(o => o.Amount);
            return income - expense;
        }

        public IDictionary<Guid, decimal> GroupByCategory(DateTime from, DateTime to, OperationType typeFilter)
        {
            IEnumerable<Operation> ops = _operations.GetAll().Where(o => o.Date.Date >= from.Date && o.Date.Date <= to.Date && o.Type == typeFilter);
            Dictionary<Guid, decimal> grouped = ops.GroupBy(o => o.CategoryId)
                             .ToDictionary(g => g.Key, g => g.Sum(o => o.Amount));
            return grouped;
        }
    }
}
