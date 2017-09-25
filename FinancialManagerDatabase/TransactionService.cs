using System.Collections.Generic;
using System.Data.Entity;
using FinancialManagerLibrary.Interfaces;
using FinancialManagerLibrary.Models;

namespace FinancialManagerDatabase
{
    public class TransactionService : BaseService<TransactionEntity>
    {
        public TransactionService(FinancialManagerModel model) : base(model, model.Transactions)
        {
        }
    }
}