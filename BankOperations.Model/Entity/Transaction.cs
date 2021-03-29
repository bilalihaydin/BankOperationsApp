using BankOperations.Model.Core;
using BankOperationsApp.Common.Constant;
using System;

namespace BankOperations.Model.Entity
{
    public class Transaction : IEntity
    {
        public int senderAccountNumber { get; set; }
        public int receiverAccountNumber { get; set; }
        private decimal _amount;
        public decimal amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = Math.Round(value, CommonConstant.RoundingValue);
            }
        }
    }
}