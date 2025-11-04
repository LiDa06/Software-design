using ConsoleApp.Models;
using ConsoleApp.Repositories;
using ConsoleApp.Domain;

namespace ConsoleApp.Facades
{
    public class BankAccountFacade(IRepository<BankAccount> accounts, Factory factory)
    {
        private readonly IRepository<BankAccount> _accounts = accounts;
        private readonly Factory _factory = factory;

        public BankAccount CreateAccount(string name, decimal balance = 0)
        {
            BankAccount acc = _factory.CreateBankAccount(name, balance);
            _accounts.Add(acc);
            return acc;
        }

        public IEnumerable<BankAccount> GetAll()
        {
            return _accounts.GetAll();
        }

        public BankAccount Get(Guid id)
        {
            return _accounts.Get(id);
        }

        public void Delete(Guid id)
        {
            _accounts.Remove(id);
        }

        public void Rename(Guid id, string? newName)
        {
            BankAccount acc = _accounts.Get(id);
            if (acc == null)
            {
                return;
            }

            acc.ChangeName(newName ?? "");
            _accounts.Update(acc);
        }

        public void ChangeBalance(Guid id, decimal amount)
        {
            BankAccount acc = _accounts.Get(id);
            if (acc == null)
            {
                return;
            }

            acc.ChangeBalance(amount);
            _accounts.Update(acc);
        }

        public void SetBalance(Guid id, decimal balance)
        {
            BankAccount acc = _accounts.Get(id);
            if (acc == null)
            {
                return;
            }

            acc.SetBalance(balance);
            _accounts.Update(acc);
        }
    }
}
