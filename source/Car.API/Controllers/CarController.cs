using System;
using System.Collections.Generic;
using Car.Domain.Entities;
using Car.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Car.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarServices _carServices;
        private readonly ILogger<CarController> _logger;
        public CarController(ICarServices carServices, ILogger<CarController> logger)
        {
            _carServices = carServices;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CarEntity>> GetAll()
        {
            try
            {
                _logger.LogInformation("Received get request");

                return Ok(_carServices.GetAll());
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        public ActionResult<string> Insert([FromBody] CarEntity car)
        {
            try
            {
                _logger.LogInformation("Received post request");

                if (!ModelState.IsValid) return BadRequest(ModelState);

                _carServices.Insert(car);
                return Ok("success");

            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpGet]
        [Route("brand/{brand}")]
        public ActionResult<IEnumerable<CarEntity>> GetByBrand(string brand)
        {
            try
            {
                _logger.LogInformation("Received get request");

                return Ok(_carServices.GetByBrand(brand));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpDelete]
        [Route("delete/{key}")]
        public ActionResult<string> Delete(Guid key)
        {
            try
            {
                _logger.LogInformation("Received get request");
                _carServices.Delete(key);
                return Ok("success");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }
    }
}