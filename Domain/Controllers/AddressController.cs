using Domain.Interfaces.Services;
using Domain.DTO;
using Microsoft.AspNetCore.Mvc;


namespace Domain.Controllers
{
    public class AddressController : BaseController
    {

        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddressDTO address)
            => Ok(new AddressDTO().FromModel(_addressService.Create(address)));


        [HttpGet]
        public IActionResult Get()
            => Ok(_addressService.Get().Select(a => new AddressDTO().FromModel(a)).ToList());



        [HttpGet("{id}")]
        public IActionResult Get(int id)
            => Ok(new AddressDTO().FromModel(_addressService.Get(id)));


        [HttpPut]
        public IActionResult Update([FromBody] AddressDTO address)
            => Ok(new AddressDTO().FromModel(_addressService.Update(address)));


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
            => Ok(new AddressDTO().FromModel(_addressService.Delete(id)));
    }
}

