using System;
using System.Collections.Generic;
using System.Text;

namespace BankOperationsApp.Common.Constant
{
    public static class CommonConstant
    {
        /// <summary>
        /// Valid Currency Codes
        /// </summary>
        public static string[] CurrencyCodes = { "TRY", "USD", "EUR" };
        /// <summary>
        /// Rounding decimal value
        /// </summary>
        public const int RoundingValue = 2;
        /// <summary>
        /// Response Default Success Message
        /// </summary>
        public const string SuccessMessage = "Success";
        /// <summary>
        /// Response Default Error Message
        /// </summary>
        public const string ErrorMessage = "Error";
        /// <summary>
        /// General Using 0
        /// </summary>
        public const byte _zero = 0;
    }
}
