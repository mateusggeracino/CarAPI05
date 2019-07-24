using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Car.Business.Interfaces;
using Car.Domain.Entities;
using Car.Services.Interfaces;

namespace Car.Services
{
    public class CarServices : ICarServices
    {
        private readonly ICarBusiness _carBusiness;

        public CarServices(ICarBusiness carBusiness)
        {
            _carBusiness = carBusiness;
        }

        public void Delete(Guid key)
        {
            _carBusiness.Delete(key);
        }

        public CarEntity Insert(CarEntity car)
        {
            return _carBusiness.Insert(car);
        }

        public List<CarEntity> GetAll()
        {
            return _carBusiness.GetAll();
        }

        public List<CarEntity> GetByBrand(string brand)
        {
            return _carBusiness.GetByBrand(brand);
        }
    }
}