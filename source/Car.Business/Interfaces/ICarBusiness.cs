using System;
using System.Collections.Generic;
using Car.Domain.Entities;

namespace Car.Business.Interfaces
{
    public interface ICarBusiness
    {
        bool Delete(Guid key);
        CarEntity Insert(CarEntity car);
        List<CarEntity> GetAll();
        List<CarEntity> GetByBrand(string brand);
    }
}