using System;

namespace FinancialManagerLibrary.Models
{
    public class TransactionEntity
    {
        public int Id { get; set; }
        public TransactionItemType SourceType { get; set; }
        public int SourceId { get; set; }

        public TransactionItemType TargetType { get; set; }
        public int TargetId { get; set; }

        public double Amount { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }

        public Currency Currency { get; set; }
    }
}