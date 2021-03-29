using BankOperations.Model.Entity;
using BankOperations.Model.Model;
using BankOperations.Service.Interface;

namespace BankOperations.Service.Services.TransactionService
{
    public interface ITransactionService : IEntityService<Transaction>
    {
        ServiceResponseModel Transaction(Transaction transaction);
    }
}
