using Domain.Interfaces.Services;
using Domain.DTO;
using Microsoft.AspNetCore.Mvc;


namespace Domain.Controllers
{
    public class AddressController: BaseController 
    {
        
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddressDTO address)
            => Ok(_addressService.Create(address.ToModel()));

        
        [HttpGet]
        public IActionResult Get()
            => Ok(_addressService.Get());



        [HttpGet("{id}")]
        public IActionResult Get(int id)
            => Ok(_addressService.Get(id));

         
        [HttpPut]
        public IActionResult Update([FromBody] AddressDTO address)
            => Ok(_addressService.Update(address.ToModel()));
            

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
            => Ok(_addressService.Delete(id));
    }
}

