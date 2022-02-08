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

        [HttpPost("UpdateOrCreate")]
        public IActionResult UpdateOrCreate([FromBody] CarDTO car)
            => Ok(new CarDTO().FromModel(_carService.Create(car)));


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

        [HttpGet("getBySistemVersion/{sistemVersion}")]
        public IActionResult GetBySistemVersion(int sistemVersion)
            => Ok(_carService.GetBySistemVersion(sistemVersion).Select(c => new CarDTO().FromModel(c)));

        [HttpGet("getBySistemVersionRange/{startSistemVersion}/{endSistemVersion}")]
        public IActionResult GetBySistemVersionRange(int startSistemVersion, int endSistemVersion)
            => Ok(_carService.GetBySistemVersionRange(startSistemVersion, endSistemVersion).Select(c => new CarDTO().FromModel(c)));


        [HttpPut]
        public IActionResult Update([FromBody] CarDTO car)
            => Ok(new CarDTO().FromModel(_carService.Update(car)));


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
            => Ok(new CarDTO().FromModel(_carService.Delete(id)));
    }
}

