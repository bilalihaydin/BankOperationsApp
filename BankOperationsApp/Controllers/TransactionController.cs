using BankOperations.Model.Entity;
using BankOperations.Model.Model;
using BankOperations.Service.Services.TransactionService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BankOperationsApp.Controllers
{
    [ApiController]
    [Route("")]
    public class TransactiontController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public TransactiontController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost("CreateMoneyTransaction")]
        public ResponseModel<Transaction> CreateTransactiont(Transaction transaction)
        {
            ServiceResponseModel serviceResponseModel = this._transactionService.Transaction(transaction);

            ResponseModel<Transaction> responseModel = new ResponseModel<Transaction>()
            {
                message = serviceResponseModel.Message,
                data = transaction,
                isError = serviceResponseModel.isError
            };

            return responseModel;
        }

        [HttpGet("GetListofMoneyTransactions")]
        public ResponseModel<List<Transaction>> GetListOfTransactionts()
        {
            ResponseModel<List<Transaction>> responseModel = new ResponseModel<List<Transaction>>();

            try
            {
                List<Transaction> transactionList = this._transactionService.GetList();
                responseModel.data = transactionList;
                responseModel.Success();
            }
            catch (System.Exception)
            {
                responseModel.Error();
            }

            return responseModel;
        }
    }
}
