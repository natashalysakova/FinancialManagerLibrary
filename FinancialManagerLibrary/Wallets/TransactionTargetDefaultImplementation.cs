using FinancialManagerLibrary.Transactions;

namespace FinancialManagerLibrary.Wallets
{
    internal class TransactionTargetDefaultImplementation : ITransactionTarget
    {
        public double IncreaseBalance(double balance, double amount)
        {
            return balance += amount;
        }
    }
}