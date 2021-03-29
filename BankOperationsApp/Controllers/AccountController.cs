using BankOperations.Model.Entity;
using BankOperations.Model.Model;
using BankOperations.Service.Services.AccountService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BankOperationsApp.Controllers
{
    [ApiController]
    [Route("")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("CreateAccount")]
        public ResponseModel<Account> CreateAccount(Account account)
        {
            ServiceResponseModel serviceResponseModel = this._accountService.Add(account);

            ResponseModel<Account> responseModel = new ResponseModel<Account>()
            {
                message = serviceResponseModel.Message,
                data = account,
                isError = serviceResponseModel.isError
            };

            return responseModel;
        }

        [HttpGet("GetListofAccounts")]
        public ResponseModel<List<Account>> GetListOfAccounts()
        {
            ResponseModel<List<Account>> responseModel = new ResponseModel<List<Account>>();

            try
            {
                List<Account> accountList = this._accountService.GetList();
                responseModel.data = accountList;
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
