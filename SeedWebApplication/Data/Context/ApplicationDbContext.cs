using Microsoft.EntityFrameworkCore;
using SeedWebApplication.Entities;

namespace SeedWebApplication.Data.Context
{
#nullable disable
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public WeatherForecast WeatherForecasts { get; set; }
    }
}
