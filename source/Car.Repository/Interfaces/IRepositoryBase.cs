using System;
using System.Collections.Generic;

namespace Car.Repository.Interfaces
{
    /// <summary>
    /// Contrato responsável pela implementação do crud genérico
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryBase<T>
    {
        T Insert(T obj);
        void Delete(T obj);
        List<T> GetAll();
        List<T> Find(Func<T, bool> predicate);
    }
}