using FinancialManagerLibrary.Transactions;

namespace FinancialManagerLibrary.Interfaces
{
    public interface ITarget : ITransactionItem
    {
        ITransactionTarget TargetImplementation { get; }
        void IncreaseBalance(double amount);
    }
}