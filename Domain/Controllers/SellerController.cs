using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Domain.Controllers
{
    public class SellerController : BaseController
    {

        private readonly ISellerService _sellerService;

        public SellerController(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Seller seller)
            => Ok(_sellerService.Create(seller));


        [HttpGet]
        public IActionResult Get()
            => Ok(_sellerService.Get());



        [HttpGet("{id}")]
        public IActionResult Get(int id)
            => Ok(_sellerService.Get(id));


        [HttpPut]
        public IActionResult Update([FromBody] Seller seller)
            => Ok(_sellerService.Update(seller));


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
            => Ok(_sellerService.Delete(id));
    }
}

