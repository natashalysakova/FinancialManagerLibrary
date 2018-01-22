using System;
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

            PriceService = new BaseService<PriceEntity>(model);
            RecordService = new BaseService<RecordEntity>(model);
            TarifService = new BaseService<TarifEntity>(model);
        }

        public IDataService<CategoryEntity> CategoryService { get; }
        public IDataService<WalletEntity> WalletService { get; }
        public IDataService<TransactionEntity> TransactionService { get; }
        public IDataService<IncomeEntity> IncomeService { get; }

        public IDataService<PriceEntity> PriceService { get; }
        public IDataService<TarifEntity> TarifService { get; }
        public IDataService<RecordEntity> RecordService { get; }
    }
}