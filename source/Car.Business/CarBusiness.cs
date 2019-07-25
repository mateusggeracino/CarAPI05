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
        private readonly IRepositoryBase<CarEntity> _carRepository;

        public CarBusiness(IRepositoryBase<CarEntity> carRepository)
        {
            _carRepository = carRepository;
        }
        
        public void Delete(Guid key)
        {
            var car = _carRepository.Find(x => x.UniqueKey == key).First();

            _carRepository.Delete(car);
        }

        public CarEntity Insert(CarEntity car)
        {
            car.Id = AutoIncrementId();
            car.UniqueKey = Guid.NewGuid();
            return _carRepository.Insert(car);
        }

        private int AutoIncrementId()
        {
            var maxId = 0;
            var allCars = GetAll();
            if (allCars != null && allCars.Any())
                maxId = allCars.Max(x => x.Id);

            return maxId + 1;
        }

        public List<CarEntity> GetAll()
        {
            return _carRepository.GetAll("Car");
        }

        public List<CarEntity> GetByBrand(string brand)
        {
            return _carRepository.Find(x => x.Brand.ToLower().Contains(brand.ToLower()));
        }
    }
}