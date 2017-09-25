using FinancialManagerLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagerDatabase
{
    public abstract class BaseService<T> : IDataService<T> where T:class
    {
        private readonly FinancialManagerModel _model;
        private readonly DbSet<T> _dbSet;

        public BaseService(FinancialManagerModel model, DbSet<T> dbSet)
        {
            _model = model;
            _dbSet = dbSet;
        }

        public T Add(T category)
        {
            _dbSet.Add(category);
            _model.SaveChanges();
            return category;
        }

        public bool Delete(int id)
        {
            var category = _model.Categories.Find(id);
            if (category != null)
            {
                _model.Entry(category).State = EntityState.Deleted;
                _model.SaveChanges();
                return true;
            }

            return false;
        }

        public T Get(int id)
        {
            var categoryEntity = _dbSet.Find(id);
            return categoryEntity;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }

        public T Update(T category)
        {
            _model.Entry(category).State = EntityState.Modified;
            _model.SaveChanges();
            return category;
        }

    }
}
