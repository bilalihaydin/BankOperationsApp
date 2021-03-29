using BankOperations.Model.Entity;
using BankOperations.Model.Model;
using BankOperations.Repository.Base;
using BankOperations.Service.Concrete;
using BankOperationsApp.Common.Constant;
using System.Collections.Generic;
using System.Linq;

namespace BankOperations.Service.Services.AccountService
{
    public class AccountService : EntityService<Account>, IAccountService
    {
        private readonly string _notUniqueMessage = "Account Number is not unique";
        private readonly string _currencyCodeNotValid = "Currency code is not valid. ('TRY', 'USD', 'EUR')";
        public AccountService(IRepository<Account> repositoryAccount) : base(repositoryAccount)
        {

        }

        public ServiceResponseModel Add(Account account)
        {
            ServiceResponseModel serviceResponseModel = ValidationControl(account);

            if (serviceResponseModel.isError == false)
            {
                serviceResponseModel.isError = base.Add(account) == false;
            }

            return serviceResponseModel.Response(serviceResponseModel.isError, serviceResponseModel.Message);
        }

        private ServiceResponseModel ValidationControl(Account account)
        {
            ServiceResponseModel serviceResponseModel = new ServiceResponseModel();
            serviceResponseModel = serviceResponseModel.Response(false);

            List<Account> accountList = this.GetList();

            if (accountList != null && accountList.Count > CommonConstant._zero)
            {
                List<int> accountNumberList = accountList.Select(condition => condition.accountNumber).ToList();
                List<decimal> balanceList = accountList.Select(condition => condition.balance).ToList();

                if (isUnique(accountNumberList, account.accountNumber) == false)
                {
                    serviceResponseModel.isError = true;
                    serviceResponseModel.Message = _notUniqueMessage;
                }
            }

            if (CurrencyIsValid(account.currencyCode))
            {
                serviceResponseModel.isError = true;

                if (serviceResponseModel.Message == CommonConstant.SuccessMessage)
                {
                    serviceResponseModel.Message = _currencyCodeNotValid;
                }
                else
                {
                    serviceResponseModel.Message = serviceResponseModel.Message + ", " + _currencyCodeNotValid;
                }
            }

            return serviceResponseModel;

        }

        private bool isUnique(List<int> numberList, int number)
        {
            return numberList.Contains(number) == false;
        }

        private bool CurrencyIsValid(string currency)
        {
            return CommonConstant.CurrencyCodes.Contains(currency) == false;
        }
    }
}