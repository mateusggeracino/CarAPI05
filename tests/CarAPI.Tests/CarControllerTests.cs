using System;
using Car.Domain.Entities;
using Car.Services.Interfaces;
using Moq;
using Xunit;

namespace CarAPI.Tests
{
    public class CarControllerTests
    {
        [Fact]
        public void PostSucess()
        {
            var carServices = new Mock<ICarServices>();
            carServices.Setup(x => x.Insert(It.IsAny<CarEntity>()));

            //var carController = 
        }
    }
}
