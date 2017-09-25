using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagerLibrary.Models
{
    public interface IEntity<T>
    {
        int Id { get; set; }

        T MapToEntity();
        void MapFromEntity(T entity);
    }
}
