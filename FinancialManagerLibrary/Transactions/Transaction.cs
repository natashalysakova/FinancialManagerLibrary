using System;
using FinancialManagerLibrary.Interfaces;
using FinancialManagerLibrary.Models;
using FinancialManagerLibrary.Wallets;
using FinancialManagerLibrary.Incomes;
using FinancialManagerLibrary.Utilities;
using FinancialManagerLibrary.Strategies;

namespace FinancialManagerLibrary.Transactions
{
    public class Transaction : IEntity<TransactionEntity>
    {
        private double _amount;
        //private ITransactionStrategy strategy;

        [Obsolete]
        public Transaction()
        {
        }

        public Transaction(ISource from, ITarget to, double amount, Currency currency, DateTime date, string comment)
        {
            From = from;
            To = to;
            Amount = amount;
            Comment = comment;
            Date = date;
            Currency = currency;

            //strategy = new 

            StartTransaction();
        }

        public int Id { get; set; }

        public ISource From { get; private set; }
        public ITarget To { get; private set; }
        public DateTime Date { get; private set; }
        public string Comment { get; private set; }
        public Currency Currency { get; private set; }

        public double Amount
        {
            get { return _amount; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Amount should be positive: amount=" + value);
                _amount = value;
            }
        }

        private void StartTransaction()
        {
            double fromAmount = Amount, toAmount = Amount;

            if (From.Currency != Currency || To.Currency != Currency)
            {
                if(From.Currency != Currency)
                {
                    fromAmount = CurrencyTools.Convert(Amount, From.Currency, Currency);
                }

                if(To.Currency != Currency)
                {
                    toAmount = CurrencyTools.Convert(Amount, To.Currency, Currency);
                }
            }

            From.DecreaseBalance(fromAmount);
            To.IncreaseBalance(toAmount);

        }

        public TransactionEntity MapToEntity()
        {
            TransactionEntity entity = new TransactionEntity()
            {
                Amount = Amount,
                Comment = Comment,
                Date = Date,
                Currency = Currency,
                Id = Id,
                SourceId = From.Id,
                SourceType = From.Type,
                TargetId = To.Id,
                TargetType = To.Type
            };

            return entity;
        }

        public void MapFromEntity(TransactionEntity entity)
        {
            Amount = entity.Amount;
            Comment = entity.Comment;
            Date = entity.Date;
            Id = entity.Id;
            Currency = entity.Currency;

            switch (entity.SourceType)
            {
                case TransactionItemType.Wallet:
                    From = new Wallet();
                    break;
                case TransactionItemType.Income:
                    From = new Income();
                    break;
            }

            From.Id = entity.SourceId;

            switch (entity.TargetType)
            {
                case TransactionItemType.Category:
                    To = new Category();
                    break;
                case TransactionItemType.Wallet:
                    To = new Wallet();
                    break;
            }

            To.Id = entity.TargetId;
        }
    }
}