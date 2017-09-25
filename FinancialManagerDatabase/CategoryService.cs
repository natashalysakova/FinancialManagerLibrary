using System.Collections.Generic;
using System.Data.Entity;
using FinancialManagerLibrary.Interfaces;

using System.Linq;
using FinancialManagerLibrary.Models;

namespace FinancialManagerDatabase
{
    public class CategoryService : BaseService<CategoryEntity>
    {
        public CategoryService(FinancialManagerModel model) : base(model, model.Categories)
        {
        }
    }
}