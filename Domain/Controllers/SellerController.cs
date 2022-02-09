using Domain.DTO;
using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Create([FromBody] SellerDTO seller)
            => Ok(new SellerDTO().FromModel(_sellerService.CreateSeller(seller)));


        [HttpGet]
        public IActionResult Get()
            => Ok(_sellerService.Get().Select(s => new SellerDTO().FromModel(s)).ToList());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
            => Ok(new SellerDTO().FromModel(_sellerService.Get(id)));

        [HttpGet("getFilled/{id}")]
        public IActionResult GetFilled(int id)
            => Ok(new SellerDTO().FromModel(_sellerService.GetFilled(id)));

        [HttpGet("getTotalSalary/{id}")]
        public IActionResult GetTotalSalary(int id)
            => Ok(_sellerService.GetTotalSalary(id));

        [HttpGet("getTotalSalaryByMonth/{id}/{month}")]
        public IActionResult GetTotalSalaryByMonth(int id, int month)
            => Ok(_sellerService.GetTotalSalaryByMonth(id, month));


        [HttpPut]
        public IActionResult Update([FromBody] Seller seller)
            => Ok(new SellerDTO().FromModel(_sellerService.Update(seller)));


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
            => Ok(new SellerDTO().FromModel(_sellerService.Delete(id)));
    }
}

