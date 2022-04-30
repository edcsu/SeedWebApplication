using SeedWebApplication.DTOs;
using SeedWebApplication.Entities;

namespace SeedWebApplication.Extensions
{
    public static class AppExtensions
    {
        public static WeatherForecastDto WeatherForecastAsDto(this WeatherForecast weatherForecast)
        {
            return new WeatherForecastDto(weatherForecast.Date, weatherForecast.TemperatureC, weatherForecast.Summary);
        }
    }
}
