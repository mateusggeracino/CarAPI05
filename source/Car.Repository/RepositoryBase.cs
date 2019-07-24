using System;
using System.Collections.Generic;
using System.Linq;
using Car.Domain.Entities;
using Car.Repository.Interfaces;

namespace Car.Repository
{
    /// <summary>
    /// Classe concreta responsável por implementar as funcionalidades genéricas do crud
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RepositoryBase<T> : IRepositoryBase<T> where T : Entity
    {
        protected static List<T> _data;

        public T Insert(T obj)
        {
            _data.Add(obj);
            return obj;
        }

        public void Delete(T obj)
        {
            _data.Remove(obj);
        }

        public List<T> GetAll()
        {
            return _data;
        }

        public List<T> Find(Func<T, bool> predicate)
        {
            return _data.Where(predicate).ToList();
        }
    }
}