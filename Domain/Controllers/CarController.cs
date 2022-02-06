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
        public IActionResult Create([FromBody] Car car)
            => Ok(_carService.Create(car));


        [HttpGet]
        public IActionResult Get()
            => Ok(_carService.Get());



        [HttpGet("{id}")]
        public IActionResult Get(int id)
            => Ok(_carService.Get(id));

        [HttpGet("getByMileage/{mileage}")]
        public IActionResult GetByMileage(double mileage)
            => Ok(_carService.GetByMileage(mileage));

        [HttpGet("getBySistemVersion/{sistemVersion}")]
        public IActionResult GetBySistemVersion(int sistemVersion)
            => Ok(_carService.GetBySistemVersion(sistemVersion));


        [HttpPut]
        public IActionResult Update([FromBody] Car car)
            => Ok(_carService.Update(car));


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
            => Ok(_carService.Delete(id));
    }
}

