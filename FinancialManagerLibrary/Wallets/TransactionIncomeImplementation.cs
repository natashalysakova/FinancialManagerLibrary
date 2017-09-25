using FinancialManagerLibrary.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagerLibrary.Wallets
{
    class TransactionIncomeImplementation : ITransactionSource
    {
        public double DecreaseBalance(double balance, double amount)
        {
            return balance += amount;
        }
    }
}
