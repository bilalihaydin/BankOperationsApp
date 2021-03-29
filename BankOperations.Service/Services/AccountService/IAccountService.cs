using BankOperations.Model.Entity;
using BankOperations.Model.Model;
using BankOperations.Service.Interface;

namespace BankOperations.Service.Services.AccountService
{
    public interface IAccountService : IEntityService<Account>
    {
        ServiceResponseModel Add(Account account);
    }
}