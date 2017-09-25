using System.Collections.Generic;
using System.Linq;
using FinancialManagerLibrary;
using FinancialManagerLibrary.Utilities;
using FinancialManager.Models.OutputModels;

namespace FinancialManager.Models.Extentions
{
    public static class CategoryExtentions
    {
        public static CategoryOutputModel MapToCategoryOutputModel(this Category category)
        {
            var model = new CategoryOutputModel
            {
                Name = category.Name,
                Currency = CurrencyTools.GetCurrencySymbol(category.Currency),
                PlannedAmount = category.PlannedAmount,
                Balance = category.Balance,
                Id = category.Id,
                SubCategories = category.SubCategories.Select(x => x.MapToCategoryOutputModel())
            };

            return model;
        }
    }
}