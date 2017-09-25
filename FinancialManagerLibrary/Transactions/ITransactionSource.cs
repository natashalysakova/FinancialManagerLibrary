namespace FinancialManagerLibrary.Transactions
{
    public interface ITransactionSource
    {
        double DecreaseBalance(double balance, double amount);
    }
}