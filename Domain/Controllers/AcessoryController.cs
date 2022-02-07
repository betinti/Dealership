using Domain.Interfaces.Services;
using Domain.Models;
using Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Controllers
{

    public class AccessoryController : BaseController
    {
        private readonly IAccessoryService _accessoryService;

        public AccessoryController(IAccessoryService accessoryService)
        {
            _accessoryService = accessoryService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] AccessoryDTO accessory)
            => Ok(new AccessoryDTO().FromModel(_accessoryService.Create(accessory)));


        [HttpGet]
        public IActionResult Get()
            => Ok(_accessoryService.Get().Select(a => new AccessoryDTO().FromModel(a)).ToList());



        [HttpGet("{id}")]
        public IActionResult Get(int id)
            => Ok(new AccessoryDTO().FromModel(_accessoryService.Get(id)));


        [HttpPut]
        public IActionResult Update([FromBody] AccessoryDTO accessory)
            => Ok(new AccessoryDTO().FromModel(_accessoryService.Update(accessory)));


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
            => Ok(new AccessoryDTO().FromModel(_accessoryService.Delete(id)));
    }
}

