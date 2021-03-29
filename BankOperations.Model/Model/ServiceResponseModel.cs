using BankOperationsApp.Common.Constant;

namespace BankOperations.Model.Model
{
    public class ServiceResponseModel
    {
        public bool isError { get; set; }
        public string Message { get; set; }

        public ServiceResponseModel Response(bool isError = false, string message = CommonConstant.SuccessMessage)
        {
            if (message == CommonConstant.SuccessMessage)
            {
                if (isError == true)
                {
                    message = CommonConstant.ErrorMessage;
                }
            }

            this.isError = isError;
            this.Message = message;

            return this;
        }
    }
}
