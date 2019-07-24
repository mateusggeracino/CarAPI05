using System;
using System.Collections.Generic;

namespace Car.Repository.Interfaces
{
    public interface IRepositoryBase<T>
    {
        T Insert(T obj);
        void Delete(T obj);
        List<T> GetAll();
        List<T> Find(Func<T, bool> predicate);
    }
}