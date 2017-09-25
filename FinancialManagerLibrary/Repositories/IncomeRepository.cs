using System.Collections.Generic;
using FinancialManagerLibrary.Incomes;
using FinancialManagerLibrary.Interfaces;
using FinancialManagerLibrary.Models;

namespace FinancialManagerLibrary.Repositories
{
    public class IncomeRepository : BaseRepository<Income, IncomeEntity>
    {
        public IncomeRepository(IDataService<IncomeEntity> dataService) : base(dataService)
        {
        }
    }
}