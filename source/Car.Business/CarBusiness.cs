using System;
using System.Collections.Generic;
using System.Linq;
using Car.Business.Interfaces;
using Car.Domain.Entities;
using Car.Repository.Interfaces;

namespace Car.Business
{
    public class CarBusiness : ICarBusiness
    {
        private readonly ICarRepository _carRepository;

        public CarBusiness(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        
        public bool Delete(Guid key)
        {
            var car = _carRepository.GetByKey(key);

            return _carRepository.Delete(car);
        }

        public CarEntity Insert(CarEntity car)
        {
            car.UniqueKey = Guid.NewGuid();
            return _carRepository.Insert(car);
        }
        
        public List<CarEntity> GetAll()
        {
            return _carRepository.GetAll();
        }

        public List<CarEntity> GetByBrand(string brand)
        {
            return _carRepository.GetByBrand(brand);
        }
    }
}