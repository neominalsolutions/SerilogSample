using Microsoft.AspNetCore.Mvc;

namespace SerilogSample.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            // 0962ab5a-2202-47a8-88d8-917bbd921d7e
            //var correlationId = Guid.NewGuid().ToString();

            _logger.LogInformation($"WeatherForecast");


            try
            {
                int number = 10;

                int result = number / 0;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);

                throw;
            }


            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}