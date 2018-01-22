using FinancialManagerLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagerLibrary.Models
{
    public class TarifEntity
    {
        public int Id { get; set; }
        public IEnumerable<PriceEntity> Prices { get; set; }
        public DateTime Started { get; set; }
        public DateTime Finished { get; set; }
    }
}
