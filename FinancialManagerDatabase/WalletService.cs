using System.Collections.Generic;
using System.Data.Entity;
using FinancialManagerLibrary.Interfaces;
using FinancialManagerLibrary.Models;

namespace FinancialManagerDatabase
{
    public class WalletService : BaseService<WalletEntity>
    {
        public WalletService(FinancialManagerModel model) : base(model, model.Wallets)
        {
        }
    }
}