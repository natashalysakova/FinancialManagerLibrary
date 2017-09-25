using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagerLibrary.Interfaces
{
    public interface ITransactionItem
    {
        TransactionItemType Type { get; }
        int Id { get; set; }

        double Balance { get; set; }

        string Name { get; set; }

        Currency Currency { get; set; }

    }
}
