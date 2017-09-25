using System.Collections.Generic;
using FinancialManagerLibrary.Interfaces;
using FinancialManagerLibrary.Models;
using FinancialManagerLibrary.Transactions;

namespace FinancialManagerLibrary.Repositories
{
    public class TransactionRepository : BaseRepository<Transaction, TransactionEntity>
    {
        public TransactionRepository(IDataService<TransactionEntity> dataService) : base(dataService)
        {
        }
    }
}