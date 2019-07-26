using Car.API.Controllers;
using Car.Domain.Entities;
using Car.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
            var logger = new Mock<ILogger<CarController>>();
            carServices.Setup(x => x.Insert(It.IsAny<CarEntity>()));

            var carController = new CarController(carServices.Object, logger.Object);
            var carEntity = new CarEntity { Brand = "teste", Model = "teste", Year = "2019"};
            
            var response = carController.Insert(carEntity);

            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response.Result);

            var httpObjResult = response.Result as OkObjectResult;

            Assert.NotNull(httpObjResult);
            Assert.True(httpObjResult.StatusCode == 200);

            var value = httpObjResult.Value;

            Assert.NotNull(value);
            Assert.False(string.IsNullOrWhiteSpace(value.ToString()));
            Assert.Same("success", value);
        }

        [Fact]
        public void PostFail()
        {
            var carServices = new Mock<ICarServices>();
            var logger = new Mock<ILogger<CarController>>();
            carServices.Setup(x => x.Insert(It.IsAny<CarEntity>()));

            var carController = new CarController(carServices.Object, logger.Object);
            var carEntity = new CarEntity { Brand = "t", Model = "t", Year = "2" };

            var response = carController.Insert(carEntity);

            Assert.NotNull(response);
            Assert.IsType<BadRequestObjectResult>(response.Result);

            var httpObjResult = response.Result as BadRequestObjectResult;

            Assert.NotNull(httpObjResult);
            Assert.True(httpObjResult.StatusCode == 401);

            var value = httpObjResult.Value;

            Assert.NotNull(value);
            Assert.False(string.IsNullOrWhiteSpace(value.ToString()));
            Assert.Same("success", value);
        }
    }
}
