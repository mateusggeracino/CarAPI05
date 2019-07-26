using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Car.Domain.Entities;
using Car.Repository.Interfaces;
using Car.Repository.Utilities;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Car.Repository
{
    /// <summary>
    /// Classe concreta responsável por implementar as funcionalidades genéricas do crud
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RepositoryBase<T> : IRepositoryBase<T> where T : Entity
    {
        private readonly ILogger<RepositoryBase<T>> _logger;
        private readonly IConfiguration _config;

        public RepositoryBase(ILogger<RepositoryBase<T>> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        private IDbConnection Conn => new SqlConnection(_config.GetConnectionString("DefaultConnection"));

        public List<T> Query(string query, DynamicParameters parameters = null)
        {
            try
            {
                if (parameters == null)
                    return Conn.Query<T>(query).ToList();

                return Conn.Query<T>(query, parameters).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                if ((Conn != null) && (Conn.State != ConnectionState.Closed))
                {
                    Conn.Close();
                }
            }
        }

        public T Insert(T obj)
        {
            Conn.Insert(obj);
            return obj;
        }

        public bool Delete(T obj)
        {
            return Conn.Delete(obj);
        }

        public List<T> GetAll()
        {
            return Conn.GetAll<T>().ToList();
        }
    }
}