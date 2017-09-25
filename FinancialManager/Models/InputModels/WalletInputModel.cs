using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinancialManager.Models.InputModels
{
    public class WalletInputModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [CurrencyValidation]
        [DataType(DataType.Text)]
        public string Currency { get; set; }

        [Range(0, Double.MaxValue)]
        [DataType(DataType.Currency)]
        public double Balance { get; set; }

        [Required]
        public bool IsCreditCard { get; set; }

        [DataType(DataType.Currency)]
        public double Overdraft{ get; set; }

    }
}