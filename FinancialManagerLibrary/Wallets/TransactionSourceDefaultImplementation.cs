using FinancialManagerLibrary.Exceptions;
using FinancialManagerLibrary.Transactions;

namespace FinancialManagerLibrary.Wallets
{
    internal class TransactionSourceDefaultImplementation : ITransactionSource
    {
        public double DecreaseBalance(double balance, double amount)
        {
            if (balance - amount <= 0)
                throw new LimitReachedException(balance, amount);
            balance -= amount;

            return balance;
        }
    }
}