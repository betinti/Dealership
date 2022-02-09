using Domain.DTO;
using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;


namespace Domain.Controllers
{
    public class CarController : BaseController
    {

        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CarDTO car)
            => Ok(new CarDTO().FromModel(_carService.Create(car)));

        [HttpPost("{modelId}/{accessoryId}/{ownerId}")]
        public IActionResult CreateWithCreateds([FromBody] CarDTO car, int modelId, int accessoryId, int ownerId)
            => Ok(new CarDTO().FromModel(_carService.CreateWithCreateds(car, modelId, accessoryId, ownerId)));

        [HttpGet]
        public IActionResult Get()
            => Ok(_carService.Get().Select(c => new CarDTO().FromModel(c)));

        [HttpGet("{id}")]
        public IActionResult Get(int id)
            => Ok(new CarDTO().FromModel(_carService.Get(id)));

        [HttpGet("GetFilled/{id}")]
        public IActionResult GetFilled(int id)
            => Ok(new CarDTO().FromModel(_carService.GetFilled(id)));

        [HttpGet("getByMileage/{mileage}")]
        public IActionResult GetByMileage(double mileage)
            => Ok(_carService.GetByMileage(mileage).Select(c => new CarDTO().FromModel(c)));

        [HttpGet("getByMileageRange/{startMileage}/{endMileage}")]
        public IActionResult GetByMileageRange(double startMileage, double endMileage)
            => Ok(_carService.GetByMileageRange(startMileage, endMileage).Select(c => new CarDTO().FromModel(c)));

        [HttpGet("getBySystemVersion/{systemVersion}")]
        public IActionResult GetBySystemVersion(int systemVersion)
            => Ok(_carService.GetBySystemVersion(systemVersion).Select(c => new CarDTO().FromModel(c)));

        [HttpGet("getBySystemVersionRange/{startSistemVersion}/{endSystemVersion}")]
        public IActionResult GetBySystemVersionRange(int startSystemVersion, int endSystemVersion)
            => Ok(_carService.GetBySystemVersionRange(startSystemVersion, endSystemVersion).Select(c => new CarDTO().FromModel(c)));

        [HttpGet("getBySystemVersionAndMileage/{systemVersion}/{mileage}")]
        public IActionResult GetBySystemVersionAndMileage(int systemVersion, double mileage)
            => Ok(_carService.GetBySystemVersionAndMileage(systemVersion, mileage).Select(c => new CarDTO().FromModel(c)));


        [HttpPut]
        public IActionResult Update([FromBody] CarDTO car)
            => Ok(new CarDTO().FromModel(_carService.Update(car)));


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
            => Ok(new CarDTO().FromModel(_carService.Delete(id)));
    }
}

