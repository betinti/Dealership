using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Controllers
{
    public class ModelController : BaseController
    {

        private readonly IModelService _modelService;

        public ModelController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Model model)
            => Ok(_modelService.Create(model));


        [HttpGet]
        public IActionResult Get()
            => Ok(_modelService.Get());



        [HttpGet("{id}")]
        public IActionResult Get(int id)
            => Ok(_modelService.Get(id));


        [HttpPut]
        public IActionResult Update([FromBody] Model model)
            => Ok(_modelService.Update(model));


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
            => Ok(_modelService.Delete(id));
    }
}

