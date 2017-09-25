using System;
using FinancialManagerLibrary.Interfaces;
using FinancialManagerLibrary.Models;
using FinancialManagerLibrary.Transactions;

namespace FinancialManagerLibrary.Wallets
{
    public class Wallet : TransactionBase, ISource, ITarget, IEntity<WalletEntity>
    {
        public bool IsCreditCard { get; private set; }

        public Wallet(string name, double balance, Currency currency) : base(name, balance, currency)
        {
            Overdraft = 0;
        }

        public Wallet(string name, double balance, Currency currency, double overdraftLimit) : this(name, balance,
            currency)
        {
            IsCreditCard = true;
            Overdraft = -overdraftLimit;
            SourceImplementation = new TransactionSourceOverdraftImplementation(Overdraft);
        }

        public Wallet(WalletEntity entity)
        {
            MapFromEntity(entity);
        }

        public Wallet() : this(string.Empty, 0, Currency.UAH)
        {
        }

        public double Overdraft { get; set; }

        private ITransactionSource _transactionSource;
        public ITransactionSource SourceImplementation
        {
            get { return _transactionSource ?? (_transactionSource = new TransactionSourceDefaultImplementation()); }
            set { _transactionSource = value; }
        }

        public ITransactionTarget TargetImplementation => new TransactionTargetDefaultImplementation();

        public override TransactionItemType Type
        {
            get
            {
                return TransactionItemType.Wallet;
            }
        }

        public void DecreaseBalance(double amount)
        {
            Balance = SourceImplementation.DecreaseBalance(Balance, amount);
        }

        public void IncreaseBalance(double amount)
        {
            Balance = TargetImplementation.IncreaseBalance(Balance, amount);
        }

        public override string ToString()
        {
            return $"Wallet Name={Name} Currency={Currency} Balance={Balance}";
        }

        public WalletEntity MapToEntity()
        {
            WalletEntity entity = new WalletEntity()
            {
                Currency = Currency,
                Balance = Balance,
                Name = Name,
                Id = Id,
                IsCreditCard = IsCreditCard,
                OverdraftLimit = +Overdraft
            };

            return entity;
        }

        public void MapFromEntity(WalletEntity entity)
        {
            Currency = entity.Currency;
            Balance = entity.Balance;
            Name = entity.Name;
            Id = entity.Id;
            IsCreditCard = entity.IsCreditCard;

            if (IsCreditCard)
            {
                Overdraft = -entity.OverdraftLimit;
                SourceImplementation = new TransactionSourceOverdraftImplementation(Overdraft);
            }

        }
    }
}