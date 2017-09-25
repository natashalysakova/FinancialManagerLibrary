namespace FinancialManagerLibrary.Transactions
{
    public interface ITransactionTarget
    {
        double IncreaseBalance(double balance, double amount);
    }
}