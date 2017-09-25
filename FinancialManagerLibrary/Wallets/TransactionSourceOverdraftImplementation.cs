using FinancialManagerLibrary.Exceptions;
using FinancialManagerLibrary.Transactions;

namespace FinancialManagerLibrary.Wallets
{
    internal class TransactionSourceOverdraftImplementation : ITransactionSource
    {
        private readonly double _overdraftLimit;

        public TransactionSourceOverdraftImplementation(double overDraftLimit)
        {
            _overdraftLimit = overDraftLimit;
        }

        public double DecreaseBalance(double balance, double amount)
        {
            if (balance - amount < _overdraftLimit)
                throw new OverdraftLimitReachedException(+_overdraftLimit, balance, amount);
            balance -= amount;
            return balance;
        }
    }
}