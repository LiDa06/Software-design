using ConsoleApp.Models;
using ConsoleApp.Repositories;
using ConsoleApp.Domain;

namespace ConsoleApp.Facades
{
    public class OperationFacade(IRepository<Operation> operations,
                           IRepository<BankAccount> accounts,
                           IRepository<Category> categories,
                           Factory factory)
    {
        private readonly IRepository<Operation> _operations = operations;
        private readonly IRepository<BankAccount> _accounts = accounts;
        private readonly IRepository<Category> _categories = categories;
        private readonly Factory _factory = factory;

        public void AddOperation(OperationType type, Guid bankAccountId, Guid categoryId, decimal amount, DateTime date, string description)
        {
            Operation op = _factory.CreateOperation(type, bankAccountId, categoryId, amount, date, description);
            _operations.Add(op);

            decimal delta = type == OperationType.Income ? amount : -amount;

            BankAccount acc = _accounts.Get(bankAccountId);
            acc.ChangeBalance(delta);
            _accounts.Update(acc);

            _operations.Add(op);
        }

        public IEnumerable<Operation> GetAll()
        {
            return _operations.GetAll();
        }
        public Operation Get(Guid id)
        {
            return _operations.Get(id);
        }
        public void Delete(Guid id)
        {
            Operation op = _operations.Get(id);

            BankAccount acc = _accounts.Get(op.BankAccountId);
            decimal delta = op.Type == OperationType.Income ? -op.Amount : op.Amount;
            acc.ChangeBalance(delta);
            _accounts.Update(acc);

            _operations.Remove(id);
        }
    }
}
