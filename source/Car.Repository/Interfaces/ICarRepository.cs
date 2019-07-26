using System;
using System.Collections.Generic;
using Car.Domain.Entities;

namespace Car.Repository.Interfaces
{
    public interface ICarRepository : IRepositoryBase<CarEntity>
    {
        CarEntity GetByKey(Guid key);
        List<CarEntity> GetByBrand(string brand);
        List<CarEntity> GetAll();
    }
}