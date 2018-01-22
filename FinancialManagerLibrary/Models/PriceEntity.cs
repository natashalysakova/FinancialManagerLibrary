using FinancialManagerLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagerLibrary.Models
{
    public class PriceEntity
    {
        public int Id { get; set; }
        public double LowBorder { get; set; }
        public double HighBorder { get; set; }
        public decimal Price { get; set; }
        public PriceType Type { get; set; }
    }
}
