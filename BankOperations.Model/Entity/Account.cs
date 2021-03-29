using BankOperations.Model.Core;
using BankOperationsApp.Common.Constant;
using System;

namespace BankOperations.Model.Entity
{
    public class Account : IEntity
    {
        public int accountNumber { get; set; }
        public string currencyCode { get; set; }
        private decimal _balance;
        public decimal balance
        {
            get
            {
                return _balance;
            }
            set
            {
                _balance = Math.Round(value, CommonConstant.RoundingValue);
            }
        }
    }
}