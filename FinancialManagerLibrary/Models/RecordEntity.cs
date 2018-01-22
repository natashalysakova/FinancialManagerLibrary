using FinancialManagerLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagerLibrary.Models
{
    public class RecordEntity
    {
        public int Id { get; set; }
        public RecordType Type { get; set; }

        public int Month { get; set; }
        public int Year { get; set; }
        public DateTime PayDate { get; set; }

        public TarifEntity Tarif { get; set; }

        public double Value { get; set; }
        public decimal Amount { get; set; }
    }
}
