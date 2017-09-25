using FinancialManagerLibrary.Interfaces;
using FinancialManagerLibrary.Models;
using FinancialManagerLibrary.Transactions;
using FinancialManagerLibrary.Wallets;
using System;

namespace FinancialManagerLibrary.Incomes
{
    public class Income : TransactionBase, ISource, IPlanned, IEntity<IncomeEntity>
    {
        public Income(string name, Currency currency) : base(name, currency)
        {
            SourceImplementation = new TransactionIncomeImplementation();
        }

        public Income(string name, Currency currency, double plannedIncome) : this(name, currency)
        {
            PlannedAmount = plannedIncome;
        }

        public Income() : this(string.Empty, Currency.UAH)
        {
        }

        public double PlannedAmount { get; set; }

        public ITransactionSource SourceImplementation { get; }

        public override TransactionItemType Type
        {
            get
            {
                return TransactionItemType.Income;
            }
        }

        public void DecreaseBalance(double amount)
        {
            Balance = SourceImplementation.DecreaseBalance(Balance, amount);
        }


        public override string ToString()
        {
            return $"Income Name={Name} Currency={Currency} Balance={Balance} PlannedAmount={PlannedAmount}";
        }

        public IncomeEntity MapToEntity()
        {
            var entity = new IncomeEntity()
            {
                Balance = Balance,
                Id = Id,
                Name = Name,
                PlannedAmount = PlannedAmount,
                Currency = Currency
            };

            return entity;
        }

        public void MapFromEntity(IncomeEntity entity)
        {
            Balance = entity.Balance;
            Name = entity.Name;
            PlannedAmount = entity.PlannedAmount;
            Id = entity.Id;
            Currency = entity.Currency;
        }
    }
}