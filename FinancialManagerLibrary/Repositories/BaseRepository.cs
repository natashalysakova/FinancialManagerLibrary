using FinancialManagerLibrary.Interfaces;
using FinancialManagerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagerLibrary.Repositories
{
    public abstract class BaseRepository<T,E> : IRepository<T> where T: IEntity<E>, new()
    {
        protected readonly IDataService<E> _dataService;

        public BaseRepository(IDataService<E> dataService)
        {
            _dataService = dataService;
        }

        public T Add(T category)
        {
            var entity = category.MapToEntity();
            var newCategoryEntity = _dataService.Add(entity);
            category.MapFromEntity(newCategoryEntity);

            return category;
        }

        public T Update(T category)
        {
            var entity = category.MapToEntity();
            var newCaatogoryEntity = _dataService.Update(entity);
            category.MapFromEntity(newCaatogoryEntity);
            return category;
        }

        public bool Delete(int id)
        {
            return _dataService.Delete(id);
        }

        public T Get(int id)
        {
            var entity = _dataService.Get(id);
            var category = new T();
            category.MapFromEntity(entity);
            return category;
        }

        public IEnumerable<T> GetAll()
        {
            var entities = _dataService.GetAll();
            return entities.Select(x => CreateFromEntity(x));
        }

        private T CreateFromEntity(E entity)
        {
            var c = new T();
            c.MapFromEntity(entity);
            return c;
        }

    }
}
