using System;
using FinancialManagerLibrary.Interfaces;

namespace FinancialManagerLibrary
{
    public abstract class TransactionBase : ITransactionItem
    {
        public TransactionBase(string name, Currency currency)
        {
            Name = name;
            Currency = currency;
            Balance = 0;
        }

        public TransactionBase(string name, double balance, Currency currency) : this(name, currency)
        {
            Balance = balance;
        }

        public TransactionBase()
        {

        }

        public double Balance
        {
            get;
            set;
        }

        public Currency Currency
        {
            get;

            set;
        }

        public int Id
        {
            get;

            set;
        }

        public string Name
        {
            get;

            set;
        }

        public abstract TransactionItemType Type { get; }
    }
}