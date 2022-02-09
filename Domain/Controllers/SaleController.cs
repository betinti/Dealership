using Domain.DTO;
using Domain.Interfaces.Services;
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
        public IActionResult Create([FromBody] SaleDTO sale)
            => Ok(new SaleDTO().FromModel(_saleService.Create(sale)));


        [HttpGet]
        public IActionResult Get()
            => Ok(_saleService.Get().Select(s => new SaleDTO().FromModel(s)).ToList());



        [HttpGet("{id}")]
        public IActionResult Get(int id)
            => Ok(new SaleDTO().FromModel(_saleService.Get(id)));

        [HttpGet("GetFilled/{id}")]
        public IActionResult GetFilled(int id)
        => Ok(new SaleDTO().FromModel(_saleService.GetFilled(id)));


        [HttpPut]
        public IActionResult Update([FromBody] SaleDTO sale)
            => Ok(new SaleDTO().FromModel(_saleService.Update(sale)));


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
            => Ok(new SaleDTO().FromModel(_saleService.Delete(id)));

        [HttpPost]
        [Route("newSaleById")]
        public IActionResult NewSaleById([FromBody] BuyCarDTO buyCar)
            => Ok(_saleService.NewSaleById(buyCar));
    }
}

