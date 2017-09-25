using System.Collections.Generic;
using System.Data.Entity;
using FinancialManagerLibrary.Interfaces;
using FinancialManagerLibrary.Models;

namespace FinancialManagerDatabase
{
    public class IncomeService : BaseService<IncomeEntity>
    {
        public IncomeService(FinancialManagerModel model) : base(model, model.Incomes)
        {
        }
    }
}