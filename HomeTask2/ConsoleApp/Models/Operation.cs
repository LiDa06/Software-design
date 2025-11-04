using System;

namespace ConsoleApp.Models
{
    public enum OperationType { Income, Expense }

    public class Operation(Guid id, OperationType type, Guid bankAccountId, Guid categoryId, decimal amount, DateTime date, string description)
    {
        public Guid Id { get; } = id;
        public OperationType Type { get; } = type;
        public Guid BankAccountId { get; } = bankAccountId;
        public Guid CategoryId { get; } = categoryId;
        public decimal Amount { get; } = amount;
        public DateTime Date { get; } = date;
        public string Description { get; } = description;
    }
}
