using Domain.DTO;
using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Controllers
{
    public class UserController : BaseController
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserDTO user)
            => Ok(new UserDTO().FromModel(_userService.Create(user)));


        [HttpPost("{addressId}")]
        public IActionResult CreateWithCreateds([FromBody] UserDTO seller, int addressId)
            => Ok(new UserDTO().FromModel(_userService.CreateWithCreateds(seller, addressId)));

        [HttpGet]
        public IActionResult Get()
            => Ok(_userService.Get());


        [HttpGet("{id}")]
        public IActionResult Get(int id)
            => Ok(new UserDTO().FromModel(_userService.Get(id)));

        [HttpGet("GetFilled/{id}")]
        public IActionResult GetFilled(int id)
            => Ok(new UserDTO().FromModel(_userService.GetFilled(id)));

        [HttpPut]
        public IActionResult Update([FromBody] UserDTO user)
            => Ok(new UserDTO().FromModel(_userService.Update(user)));


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
            => Ok(new UserDTO().FromModel(_userService.Delete(id)));
    }
}

