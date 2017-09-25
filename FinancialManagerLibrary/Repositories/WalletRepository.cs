using System.Collections.Generic;
using System.Linq;
using FinancialManagerLibrary.Interfaces;
using FinancialManagerLibrary.Models;
using FinancialManagerLibrary.Wallets;

namespace FinancialManagerLibrary.Repositories
{
    public class WalletRepository : BaseRepository<Wallet, WalletEntity>
    {
        public WalletRepository(IDataService<WalletEntity> dataService) : base(dataService)
        {
        }
    }
}