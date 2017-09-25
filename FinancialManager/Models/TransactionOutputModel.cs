using System;

namespace FinancialManager.Models
{
    public class TransactionOutputModel
    {
        public DateTime Date { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public double Amount { get; set; }
        public string Comment { get; set; }
    }
}