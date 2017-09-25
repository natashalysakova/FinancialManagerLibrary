using System;

namespace FinancialManager.Models.OutputModels
{
    public class TransactionOutputModel
    {
        public DateTime Date { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public double Amount { get; set; }
        public string Comment { get; set; }
        public string Currency { get; set; }
        public int Id { get; internal set; }
    }
}