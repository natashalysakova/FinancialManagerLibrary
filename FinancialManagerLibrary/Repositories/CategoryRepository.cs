using System.Collections.Generic;
using System.Linq;
using FinancialManagerLibrary.Interfaces;
using FinancialManagerLibrary.Models;

namespace FinancialManagerLibrary.Repositories
{
    public class CategoryRepository : BaseRepository<Category, CategoryEntity>
    {
        public CategoryRepository(IDataService<CategoryEntity> dataService) : base(dataService)
        {
        }
    }
}
