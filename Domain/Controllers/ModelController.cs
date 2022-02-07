using Domain.DTO;
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
        public IActionResult Create([FromBody] ModelDTO model)
            => Ok(new ModelDTO().FromModel(_modelService.Create(model)));


        [HttpGet]
        public IActionResult Get()
            => Ok(_modelService.Get().Select(m => new ModelDTO().FromModel(m)).ToList());



        [HttpGet("{id}")]
        public IActionResult Get(int id)
            => Ok(new ModelDTO().FromModel(_modelService.Get(id)));


        [HttpPut]
        public IActionResult Update([FromBody] ModelDTO model)
            => Ok(new ModelDTO().FromModel(_modelService.Update(model)));


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
            => Ok(new ModelDTO().FromModel(_modelService.Delete(id)));
    }
}

