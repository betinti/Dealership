using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Domain.Controllers
{
    public class UserController : BaseController
    {

        private readonly IUserService _userService;

        public UserController(IUserService _userService)
        {
            _userService = _userService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
            => Ok(_userService.Create(user));


        [HttpGet]
        public IActionResult Get()
            => Ok(_userService.Get());



        [HttpGet("{id}")]
        public IActionResult Get(int id)
            => Ok(_userService.Get(id));


        [HttpPut]
        public IActionResult Update([FromBody] User user)
            => Ok(_userService.Update(user));


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
            => Ok(_userService.Delete(id));
    }
}

