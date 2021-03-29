using BankOperationsApp.Common.Constant;
using System;

namespace BankOperations.Model.Model
{
    public class ResponseModel<T>
    {
        public string message { get; set; }
        public bool isError { get; set; }
        public Guid referenceNumber => Guid.NewGuid();
        public T data { get; set; }

        public ResponseModel<T> Success(bool isError = false, string message = CommonConstant.SuccessMessage)
        {
            this.isError = isError;
            this.message = message;

            return this;
        }

        public ResponseModel<T> Error(bool isError = true, string message = CommonConstant.ErrorMessage)
        {
            this.isError = isError;
            this.message = message;

            return this;
        }
    }
}
