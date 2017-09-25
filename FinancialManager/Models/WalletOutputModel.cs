using FinancialManagerLibrary;

namespace FinancialManager.Models
{
    public class WalletOutputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public bool IsCreditCard { get; set; }
        public double Overdraft { get; set; }
        public string Currency { get; set; }
    }
}