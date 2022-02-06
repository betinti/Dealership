using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Controllers
{
    public class OwnerController: BaseController
    {

        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Owner owner)
            => Ok(_ownerService.Create(owner));

        
        [HttpGet]
        public IActionResult Get()
            => Ok(_ownerService.Get());



        [HttpGet("{id}")]
        public IActionResult Get(int id)
            => Ok(_ownerService.Get(id));

         
        [HttpPut]
        public IActionResult Update([FromBody] Owner owner)
            => Ok(_ownerService.Update(owner));
            

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
            => Ok(_ownerService.Delete(id));
    }
}

