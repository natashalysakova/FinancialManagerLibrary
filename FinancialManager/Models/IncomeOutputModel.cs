using FinancialManagerLibrary;

namespace FinancialManager.Models
{
    public class IncomeOutputModel
    {
        public string Name { get; set; }
        public double PlannedAmount { get; set; }
        public double Balance { get; set; }
        public Currency Currency { get; set; }
    }
}