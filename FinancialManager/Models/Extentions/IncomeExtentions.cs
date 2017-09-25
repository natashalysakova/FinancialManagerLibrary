using FinancialManager.Models.OutputModels;
using FinancialManagerLibrary.Incomes;
using FinancialManagerLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialManager.Models.Extentions
{
    public static class IncomeExtentions
    {
        public static IncomeOutputModel MapToIncomeOutputModel(this Income income)
        {
            IncomeOutputModel model = new IncomeOutputModel()
            {
                Name = income.Name,
                Balance = income.Balance,
                Currency = CurrencyTools.GetCurrencySymbol(income.Currency),
                PlannedAmount = income.PlannedAmount,
                Id = income.Id
            };
            return model;
        }
    }
}