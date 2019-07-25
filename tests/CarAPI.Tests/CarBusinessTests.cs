using System;
using System.Collections.Generic;
using Car.Business;
using Car.Domain.Entities;
using Car.Repository;
using Car.Repository.Interfaces;
using Moq;
using Xunit;

namespace CarAPI.Tests
{
    public class CarBusinessTests
    {
        [Fact]
        public void InsertSucess()
        {
            var carRepository = new Mock<IRepositoryBase<CarEntity>>();
            var carEntity = new CarEntity { Brand = "Teste", Model = "Teste", Year = "Teste" };
            carRepository.Setup(x => x.Insert(It.IsAny<CarEntity>())).Returns(carEntity);

            var carBusiness = new CarBusiness(carRepository.Object);

            var result = carBusiness.Insert(carEntity);

            Assert.True(result.Id != 0);
            Assert.True(result.UniqueKey != Guid.Empty);
        }

        [Fact]
        public void InsertFail()
        {
            var carRepository = new Mock<IRepositoryBase<CarEntity>>();
            var carEntity = new CarEntity { Brand = "Teste", Model = "Teste", Year = "Teste" };
            carRepository.Setup(x => x.Insert(It.IsAny<CarEntity>())).Returns(carEntity);

            var carBusiness = new CarBusiness(carRepository.Object);
            var result = carBusiness.Insert(carEntity);

            Assert.False(result.Id == 0);
            Assert.False(result.UniqueKey == Guid.Empty);
        }

        [Fact]
        public void GetAllSucess()
        {
            var carRepository = new Mock<IRepositoryBase<CarEntity>>();
            carRepository.Setup(x => x.GetAll()).Returns(GetCars);
            var carBusiness = new CarBusiness(carRepository.Object);

            var result = carBusiness.GetAll();

            Assert.NotNull(result);
            Assert.True(result.Count == 3);
        }

        [Fact]
        public void GetAllFail()
        {
            var carRepository = new Mock<IRepositoryBase<CarEntity>>();
            carRepository.Setup(x => x.GetAll()).Returns(GetCars);
            var carBusiness = new CarBusiness(carRepository.Object);

            var result = carBusiness.GetAll();

            Assert.False(result.Count != 3);
        }

        [Fact]
        public void GetByBrandSucess()
        {
            var carRepository = new Mock<IRepositoryBase<CarEntity>>();
            carRepository.Setup(x => x.Find(It.IsAny<Func<CarEntity, bool>>()));//.Returns(GetCars);
            var carBusiness = new CarBusiness(carRepository.Object);

            var result = carBusiness.GetByBrand("Fiat");

        }

        private List<CarEntity> GetCars()
        {
            return new List<CarEntity>
            {
                new CarEntity{Id = 1, UniqueKey = Guid.NewGuid(), Brand = "Fiat", Model = "Uno", Year = "1550"},
                new CarEntity{Id = 2, UniqueKey = Guid.NewGuid(), Brand = "Lamborghini", Model = "Urus", Year = "2025"},
                new CarEntity{Id = 3, UniqueKey = Guid.NewGuid(), Brand = "Renault", Model = "Sandero", Year = "2015"}
            };
        }
    }
}