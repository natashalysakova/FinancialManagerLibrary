using FinancialManagerLibrary.Interfaces;
using FinancialManagerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagerLibrary.Repositories
{
    public class BaseRepository<T,E> : IRepository<T> where T: IEntity<E>, new()
    {
        protected readonly IDataService<E> _dataService;

        public BaseRepository(IDataService<E> dataService)
        {
            _dataService = dataService;
        }

        public virtual T Add(T item)
        {
            var entity = item.MapToEntity();
            var newCategoryEntity = _dataService.Add(entity);
            item.MapFromEntity(newCategoryEntity);

            return item;
        }

        public virtual T Update(T item)
        {
            var entity = item.MapToEntity();
            var newCaatogoryEntity = _dataService.Update(entity);
            item.MapFromEntity(newCaatogoryEntity);
            return item;
        }

        public virtual bool Delete(int id)
        {
            return _dataService.Delete(id);
        }

        public virtual T Get(int id)
        {
            var entity = _dataService.Get(id);
            var item = new T();
            item.MapFromEntity(entity);
            return item;
        }

        public virtual IEnumerable<T> GetAll()
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
