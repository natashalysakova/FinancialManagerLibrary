using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FinancialManagerLibrary;

namespace FinancialManager.Models.InputModels
{
    public class CategoryInputModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [CurrencyValidation]
        [DataType(DataType.Text)]
        public string Currency { get; set; }

        [Required]
        [Range(0, Double.MaxValue)]
        [DataType(DataType.Currency)]
        public double PlannedAmount { get; set; }
    }

    public class CurrencyValidationAttribute : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            Currency c;
            if (Enum.TryParse(value.ToString(), out c))
            {
                return true;
            }

            ErrorMessage = $"Incorrect currency='{value.ToString()}'";
            return false;
        }
    }
}