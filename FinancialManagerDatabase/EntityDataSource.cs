using FinancialManagerLibrary.Interfaces;
using FinancialManagerLibrary.Models;

namespace FinancialManagerDatabase
{
    public class EntityDataSource : IFinancialDataSource
    {
        public EntityDataSource(string contextName)
        { 
            FinancialManagerModel model = new FinancialManagerModel(contextName);
            CategoryService = new CategoryService(model);
            WalletService = new WalletService(model);
            TransactionService = new TransactionService(model);
            IncomeService = new IncomeService(model);
        }

        public IDataService<CategoryEntity> CategoryService { get;  }
        public IDataService<WalletEntity> WalletService { get; }
        public IDataService<TransactionEntity> TransactionService { get;  }
        public IDataService<IncomeEntity> IncomeService { get;  }

    }
}