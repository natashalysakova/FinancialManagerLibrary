using FinancialManagerLibrary;

namespace FinancialManager.Models.OutputModels
{
    public class IncomeOutputModel
    {
        public string Name { get; set; }
        public double PlannedAmount { get; set; }
        public double Balance { get; set; }
        public string Currency { get; set; }
        public int Id { get; set; }
    }
}