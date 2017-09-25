using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinancialManagerLibrary.Transactions;

namespace FinancialManager.Models.OutputModels
{
    public class MainPageOutputModel
    {
        public IEnumerable<CategoryOutputModel> Categories { get; set; }
        public IEnumerable<WalletOutputModel> Wallets { get; set; }
        public IEnumerable<TransactionOutputModel> Transactions { get; set; }
        public IEnumerable<IncomeOutputModel> Incomes { get; set; }

        public MainPageOutputModel()
        {
            Categories = new List<CategoryOutputModel>();
            Wallets = new List<WalletOutputModel>();
            Transactions = new List<TransactionOutputModel>();
            Incomes = new List<IncomeOutputModel>();
        }
    }
}