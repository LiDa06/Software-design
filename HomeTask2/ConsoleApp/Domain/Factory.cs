using ConsoleApp.Models;

namespace ConsoleApp.Domain
{
    public class Factory
    {
        public BankAccount CreateBankAccount(string name, decimal initialBalance = 0)
        {
            return new BankAccount(Guid.NewGuid(), name, initialBalance);
        }

        public Category CreateCategory(CategoryType type, string name)
        {
            return new Category(Guid.NewGuid(), type, name);
        }

        public Operation CreateOperation(OperationType type, Guid bankAccountId, Guid categoryId, decimal amount, DateTime date, string description)
        {
            return new Operation(Guid.NewGuid(), type, bankAccountId, categoryId, amount, date, description);
        }
    }
}
