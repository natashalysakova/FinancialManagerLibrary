namespace FinancialManagerLibrary.Models
{
    public class WalletEntity
    {
        public int Id { get; set; }
        public bool IsCreditCard { get; set; }
        public double OverdraftLimit { get; set; }
        public string Name { get; set; }
        public Currency Currency { get; set; }
        public double Balance { get; set; }
    }
}