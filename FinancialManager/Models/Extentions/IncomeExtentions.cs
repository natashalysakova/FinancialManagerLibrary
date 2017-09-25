using FinancialManagerLibrary.Incomes;
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
                Currency = income.Currency,
                PlannedAmount = income.PlannedAmount
            };
            return model;
        }
    }
}