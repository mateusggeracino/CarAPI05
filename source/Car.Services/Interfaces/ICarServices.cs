using Car.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Car.Services.Interfaces
{
    public interface ICarServices
    {
        void Delete(Guid key);
        CarEntity Insert(CarEntity car);
        List<CarEntity> GetAll();
        List<CarEntity> GetByBrand(string brand);
    }
}