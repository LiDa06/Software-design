using System;
using System.Collections.Generic;

namespace ConsoleApp.Repositories
{
    public interface IRepository<T>
    {
        void Add(T item);
        void Update(T item);
        void Remove(Guid id);
        T Get(Guid id);
        IEnumerable<T> GetAll();
    }
}
