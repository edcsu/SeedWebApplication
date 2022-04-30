using SeedWebApplication.Entities;

namespace SeedWebApplication.Data.Repos
{
    public interface IWeatherForecastRepo
    {
        Task<bool> SaveChangesAsync();

        IEnumerable<WeatherForecast> GetAllWeatherForecasts();

        WeatherForecast? GetWeatherForecastsById(Guid id);

        void CreateWeatherForecast(WeatherForecast forecast);

        void UpdateWeatherForecast(WeatherForecast forecast);
    }
}
