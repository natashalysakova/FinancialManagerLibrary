using FinancialManagerLibrary.Transactions;

namespace FinancialManagerLibrary.Interfaces
{
    public interface ISource : ITransactionItem
    {
        ITransactionSource SourceImplementation { get; }
        void DecreaseBalance(double amount);
    }
}