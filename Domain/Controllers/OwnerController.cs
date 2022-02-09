using Domain.DTO;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Controllers
{
    public class OwnerController : BaseController
    {

        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] OwnerDTO owner)
            => Ok(new OwnerDTO().FromModel(_ownerService.Create(owner)));

        [HttpGet]
        public IActionResult Get()
            => Ok(_ownerService.Get().Select(o => new OwnerDTO().FromModel(o)).ToList());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
            => Ok(new OwnerDTO().FromModel(_ownerService.Get(id)));

        [HttpGet("GetFilled/{id}")]
        public IActionResult GetFilled(int id)
                    => Ok(new OwnerDTO().FromModel(_ownerService.GetFilled(id)));

        [HttpPut]
        public IActionResult Update([FromBody] OwnerDTO owner)
            => Ok(new OwnerDTO().FromModel(_ownerService.Update(owner)));


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
            => Ok(new OwnerDTO().FromModel(_ownerService.Delete(id)));
    }
}

