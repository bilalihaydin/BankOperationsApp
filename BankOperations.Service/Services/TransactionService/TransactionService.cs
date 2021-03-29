using BankOperations.Model.Entity;
using BankOperations.Model.Model;
using BankOperations.Repository.Base;
using BankOperations.Service.Concrete;
using BankOperationsApp.Common.Constant;
using System.Collections.Generic;
using System.Linq;

namespace BankOperations.Service.Services.TransactionService
{
    public class TransactionService : EntityService<Transaction>, ITransactionService
    {
        private readonly IRepository<Account> _repositoryAccount;
        private readonly string _accountNotValid = "Sender or receiver account not found.";
        private readonly string _balanceNotSuitable = "Insufficient balance error.";
        private readonly string _currencyNotSuitable = "Sender and receiver acoount currency disagreement.";
        private Account _senderAccount;
        private Account _receiverAccount;
        public TransactionService(IRepository<Transaction> repositoryTransaction, IRepository<Account> repositoryAccount) : base(repositoryTransaction)
        {
            this._repositoryAccount = repositoryAccount;
            _senderAccount = new Account();
            _receiverAccount = new Account();
        }

        public ServiceResponseModel Transaction(Transaction transaction)
        {
            ServiceResponseModel serviceResponseModel = ValidationControl(transaction);

            if (serviceResponseModel.isError == false)
            {
                serviceResponseModel.isError = base.Add(transaction) == false;

                if (serviceResponseModel.isError == false)
                {
                    _repositoryAccount.Update(_senderAccount, new Account() { accountNumber = _senderAccount.accountNumber, balance = _senderAccount.balance - transaction.amount, currencyCode = _senderAccount.currencyCode });

                    _repositoryAccount.Update(_receiverAccount, new Account() { accountNumber = _receiverAccount.accountNumber, balance = _receiverAccount.balance + transaction.amount, currencyCode = _receiverAccount.currencyCode });
                }
            }

            return serviceResponseModel.Response(serviceResponseModel.isError, serviceResponseModel.Message);
        }

        private ServiceResponseModel ValidationControl(Transaction transaction)
        {
            ServiceResponseModel serviceResponseModel = new ServiceResponseModel();
            serviceResponseModel = serviceResponseModel.Response(false);

            List<Account> accountList = (List<Account>)this._repositoryAccount.GetAll();
            _senderAccount = accountList.Where(condition => condition.accountNumber == transaction.senderAccountNumber).FirstOrDefault();
            _receiverAccount = accountList.Where(condition => condition.accountNumber == transaction.receiverAccountNumber).FirstOrDefault();

            if (_senderAccount == null || _receiverAccount == null)
            {
                serviceResponseModel.Response(true, this._accountNotValid);

                return serviceResponseModel;
            }

            if (isBalanceSuitable(_senderAccount.balance, transaction.amount) == false)
            {
                serviceResponseModel = serviceResponseModel.Response(true, _balanceNotSuitable);
            }

            if (isCurrencySuitable(_senderAccount.currencyCode, _receiverAccount.currencyCode) == false)
            {
                string message = serviceResponseModel.Message == CommonConstant.SuccessMessage ? _currencyNotSuitable : serviceResponseModel.Message + ", " + _currencyNotSuitable;

                serviceResponseModel = serviceResponseModel.Response(true, message);
            }

            return serviceResponseModel;
        }

        private bool isBalanceSuitable(decimal balance, decimal amount)
        {
            if (balance <= CommonConstant._zero || amount <= CommonConstant._zero)
            {
                return false;
            }

            return balance > amount;
        }

        private bool isCurrencySuitable(string senderCurrency, string receiverCurrency)
        {
            return senderCurrency == receiverCurrency;
        }
    }
}