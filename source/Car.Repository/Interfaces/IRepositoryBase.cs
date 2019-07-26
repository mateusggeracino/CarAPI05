using System;
using System.Collections.Generic;
using Dapper;

namespace Car.Repository.Interfaces
{
    /// <summary>
    /// Contrato responsável pela implementação do crud genérico
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryBase<T>
    {
        List<T> Query(string query, DynamicParameters parameters);
        T Insert(T obj);
        bool Delete(T obj);
        List<T> GetAll();
    }
}