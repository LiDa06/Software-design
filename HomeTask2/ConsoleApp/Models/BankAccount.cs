namespace ConsoleApp.Models
{
    public class BankAccount(Guid id, string name, decimal balance)
    {
        public Guid Id { get; } = id;
        public string Name { get; private set; } = name;
        public decimal Balance { get; private set; } = balance;

        public void ChangeName(string name)
        {
            Name = name;
        }

        public void ChangeBalance(decimal value)
        {
            Balance += value;
        }

        public void SetBalance(decimal value)
        {
            Balance = value;
        }
    }
}
