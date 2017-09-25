using FinancialManagerLibrary;
using FinancialManagerLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinancialManager.Models.InputModels
{
    public class TransactionInputModel
    {
        [Required]
        public TransactionItemType FromType { get; set; }

        [Required]
        public int FromId { get; set; }

        [Required]
        public TransactionItemType ToType { get; set; }
        [Required]
        public int ToId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double Amount { get; set; }

        [Required]
        [CurrencyValidation]
        [DataType(DataType.Text)]
        public string Currency { get; set; }

        public string Comment { get; set; }
    }
}