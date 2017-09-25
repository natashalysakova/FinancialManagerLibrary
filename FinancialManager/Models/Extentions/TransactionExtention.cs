using FinancialManager.Models.OutputModels;
using FinancialManagerLibrary.Transactions;
using FinancialManagerLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialManager.Models.Extentions
{
    public static class TransactionExtention
    {
        public static TransactionOutputModel MapToTransactionOutputModel(this Transaction transaction)
        {
            TransactionOutputModel model = new TransactionOutputModel()
            {
                Amount = transaction.Amount,
                Comment = transaction.Comment,
                Date = transaction.Date,
                From = transaction.From.Name,
                To = transaction.To.Name,
                Currency = CurrencyTools.GetCurrencySymbol(transaction.Currency),
                Id = transaction.Id
            };

            return model;
        }
    }
}