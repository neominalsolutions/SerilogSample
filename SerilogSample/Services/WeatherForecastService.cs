using Serilog.Context;
using SerilogSample.Extentions;

namespace SerilogSample.Services
{
    public class WeatherForecastService
    {

        private static readonly string[] Summaries = new[]
       {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastService> _logger;
        private readonly IHttpContextAccessor _contextAccessor;

        public WeatherForecastService(ILogger<WeatherForecastService> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _contextAccessor = httpContextAccessor;
        }


        public IEnumerable<WeatherForecast> GetWeatherForecasts()
        {

           _logger.LogError("GetWeatherForecasts Service");

            string crId = _contextAccessor.HttpContext.GetCorrelationId();
            // bus.publishEvent(); // send another microservice AMQP correlationId,


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
