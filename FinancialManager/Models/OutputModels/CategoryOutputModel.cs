using System.Collections.Generic;
using FinancialManagerLibrary;

namespace FinancialManager.Models.OutputModels
{
    public class CategoryOutputModel
    {
        public int Id { get; set; }  
        public string Name { get; set; }
        public string Currency { get; set; }
        public double PlannedAmount { get; set; }
        public double Balance { get; set; }
        public IEnumerable<CategoryOutputModel> SubCategories { get; set; }
    }
}