namespace FinancialManagerLibrary.Models
{
    public class IncomeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double PlannedAmount { get; set; }
        public double Balance { get; set; }
        public Currency Currency { get; internal set; }
    }
}