using ConsoleApp.Facades;
using ConsoleApp.Models;

namespace ConsoleApp.Commands
{
    public class AddOperationCommand(OperationFacade operationFacade, OperationType type, Guid accountId, Guid categoryId, decimal amount, DateTime date, string? desc = null) : ICommand
    {
        private readonly OperationFacade _operationFacade = operationFacade;
        private readonly OperationType _type = type;
        private readonly Guid _accountId = accountId;
        private readonly Guid _categoryId = categoryId;
        private readonly decimal _amount = amount;
        private readonly DateTime _date = date;
        private readonly string _desc = desc ?? "";

        public void Execute()
        {
            _operationFacade.AddOperation(_type, _accountId, _categoryId, _amount, _date, _desc);
        }
    }
}
