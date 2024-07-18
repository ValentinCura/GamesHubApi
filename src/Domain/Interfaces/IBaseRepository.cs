using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T? GetById<TId>(TId id);
        List<T> Get();
        T? Add(T entity);
        T? Update(T entity);
        T Remove(T entity);
    }
}