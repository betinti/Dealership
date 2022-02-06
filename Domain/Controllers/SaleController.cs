using Domain.DTO;
using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Controllers
{
    public class SaleController : BaseController
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Sale sale)
            => Ok(_saleService.Create(sale));


        [HttpGet]
        public IActionResult Get()
            => Ok(_saleService.Get());



        [HttpGet("{id}")]
        public IActionResult Get(int id)
            => Ok(_saleService.Get(id));


        [HttpPut]
        public IActionResult Update([FromBody] Sale sale)
            => Ok(_saleService.Update(sale));


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
            => Ok(_saleService.Delete(id));

        [HttpPost]
        [Route("newSaleById")]
        public IActionResult NewSaleById([FromBody] BuyCarDTO buyCar)
            => Ok(_saleService.NewSaleById(buyCar));
    }
}

