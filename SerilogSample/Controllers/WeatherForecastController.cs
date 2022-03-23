using Microsoft.AspNetCore.Mvc;
using Serilog.Context;
using SerilogSample.Services;

namespace SerilogSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
       

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherForecastService _weatherForecastService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherForecastService weatherForecastService)
        {
            _logger = logger;
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
 
                _logger.LogError("GetWeatherForecast {userId}", Guid.NewGuid());


      


            return _weatherForecastService.GetWeatherForecasts();



        }
    }
}