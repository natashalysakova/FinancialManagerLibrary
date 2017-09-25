using System.Collections.Generic;

namespace FinancialManagerLibrary.Interfaces
{
    public interface IDataService<T>
    {
        T Add(T category);
        T Update(T category);
        bool Delete(int id);
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}