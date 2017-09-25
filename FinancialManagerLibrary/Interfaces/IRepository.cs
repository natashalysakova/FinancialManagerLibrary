using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace FinancialManagerLibrary.Interfaces
{
    public interface IRepository<T>
    {
        T Add(T category);
        T Update(T category);
        bool Delete(int id);
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}