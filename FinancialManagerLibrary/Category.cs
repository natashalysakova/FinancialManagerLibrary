using System.Collections.Generic;
using System.Linq;
using FinancialManagerLibrary.Interfaces;
using FinancialManagerLibrary.Models;
using FinancialManagerLibrary.Transactions;
using FinancialManagerLibrary.Wallets;
using System;

namespace FinancialManagerLibrary
{
    public class Category : TransactionBase, ITarget, IPlanned, IEntity<CategoryEntity>
    {
        public Category(string name, Currency currency) : base(name, currency)
        {
            SubCategories = new List<Category>();
            PlannedAmount = 0;
        }

        public Category(string name, Currency currency, double plannedAmount) : this(name, currency)
        {
            PlannedAmount = plannedAmount;
        }

        public Category(CategoryEntity entity) : base(string.Empty, Currency.UAH)
        {
            MapFromEntity(entity);
        }

        public Category()
        {

        }

        public IEnumerable<Category> SubCategories { get; set; }

        public double PlannedAmount { get; set; }

        public ITransactionTarget TargetImplementation => new TransactionTargetDefaultImplementation();

        public override TransactionItemType Type
        {
            get
            {
                return TransactionItemType.Category;
            }
        }

        public void IncreaseBalance(double amount)
        {
            Balance = TargetImplementation.IncreaseBalance(Balance, amount);
        }

        public override string ToString()
        {
            return $"Category Name={Name} Currency={Currency} Balance={Balance} PlannedAmount={PlannedAmount}";
        }

        public CategoryEntity MapToEntity()
        {
            var entity = new CategoryEntity
            {
                Id = Id,
                Balance = Balance,
                Currency = Currency,
                Name = Name,
                PlannedAmount = PlannedAmount,
                SubCategories = SubCategories.Select(x => x.MapToEntity())
            };
            return entity;
        }

        public void MapFromEntity(CategoryEntity entity)
        {
            Id = entity.Id;
            PlannedAmount = entity.PlannedAmount;
            SubCategories = entity.SubCategories != null
                ? entity.SubCategories.Select(x => new Category(x))
                : new List<Category>();
            Balance = entity.Balance;
            Currency = entity.Currency;
            Name = entity.Name;
        }
    }
}