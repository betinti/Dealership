using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Controllers
{
    [Route("api/Logger")]
    [ApiController]
    public class LoggerController : Controller
    {

        private readonly ILoggerService _loggerService;

        public LoggerController(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        [HttpGet]
        public IActionResult Get()
            => Ok(_loggerService.GetLogs());

    }
}

