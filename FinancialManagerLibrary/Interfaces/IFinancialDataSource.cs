using FinancialManagerLibrary.Models;

namespace FinancialManagerLibrary.Interfaces
{
    public interface IFinancialDataSource
    {
        IDataService<CategoryEntity> CategoryService { get; }
        IDataService<WalletEntity> WalletService { get; }
        IDataService<TransactionEntity> TransactionService { get; }
        IDataService<IncomeEntity> IncomeService { get; }

    }
}
