using System;
using System.Collections.Generic;
using System.Linq;
using Car.Domain.Entities;
using Car.Repository.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Car.Repository
{
    public class CarRepository : RepositoryBase<CarEntity>, ICarRepository
    {
        public CarRepository(ILogger<RepositoryBase<CarEntity>> logger, IConfiguration config) : base(logger, config)
        {
        }

        public CarEntity GetByKey(Guid key)
        {
            var query = "select * from Car where Brand like @brand";
            var parameters = new DynamicParameters();

            return Query(query, parameters).FirstOrDefault();
        }

        public List<CarEntity> GetByBrand(string brand)
        {
            var query = "select * from Car where Brand like @brand";
            var parameters = new DynamicParameters();
            parameters.Add("@brand", brand);
            return Query(query, parameters);
        }

    }
}