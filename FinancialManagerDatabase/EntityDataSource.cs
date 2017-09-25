using FinancialManagerLibrary.Interfaces;
using FinancialManagerLibrary.Models;

namespace FinancialManagerDatabase
{
    public class EntityDataSource : IFinancialDataSource
    {
        public EntityDataSource(string contextName)
        { 
            FinancialManagerModel model = new FinancialManagerModel(contextName);
            CategoryService = new BaseService<CategoryEntity>(model);
            WalletService = new BaseService<WalletEntity>(model);
            TransactionService = new BaseService<TransactionEntity>(model);
            IncomeService = new BaseService<IncomeEntity>(model);
        }

        public IDataService<CategoryEntity> CategoryService { get;  }
        public IDataService<WalletEntity> WalletService { get; }
        public IDataService<TransactionEntity> TransactionService { get;  }
        public IDataService<IncomeEntity> IncomeService { get;  }

    }
}