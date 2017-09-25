using System.Collections.Generic;
using System.Linq;

namespace FinancialManagerLibrary.Models
{
    public class CategoryEntity
    {
 
        public int Id { get; set; }
        public string Name { get; set; }
        public Currency Currency { get; set; }
        public double PlannedAmount { get; set; }
        public double Balance { get; set; }
        public IEnumerable<CategoryEntity> SubCategories { get; set; }
    }
}