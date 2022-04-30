using SeedWebApplication.Data.Context;
using SeedWebApplication.Entities;

namespace SeedWebApplication.Data.Repos
{
    public class WeatherForecastRepo : IWeatherForecastRepo
    {
        private readonly ApplicationDbContext _context;

        public WeatherForecastRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async void CreateWeatherForecast(WeatherForecast forecast)
        {
            await _context.AddAsync(forecast);
        }

        public IEnumerable<WeatherForecast> GetAllWeatherForecasts()
        {
           return _context.WeatherForecasts.ToList();
        }

        public WeatherForecast? GetWeatherForecastsById(Guid id)
        {
            return _context.WeatherForecasts.FirstOrDefault(p => p.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public void UpdateWeatherForecast(WeatherForecast forecast)
        {
            _context.WeatherForecasts.Update(forecast);
        }
    }
}
