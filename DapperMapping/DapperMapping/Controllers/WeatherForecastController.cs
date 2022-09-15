using DapperMapping.Api.DataAcces;
using DapperMapping.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperMapping.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        private readonly UnitWork _unitWork;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, UnitWork unitWork)
        {
            _logger = logger;
            _unitWork = unitWork;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<ContactsResponse> Get()
        {
            return _unitWork.ContactsRepository.All();
        }

    }
}