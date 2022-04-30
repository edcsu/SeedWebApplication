using SeedWebApplication.Data.Context;
using SeedWebApplication.Entities;

namespace SeedWebApplication.Data
{
    public static class SeedData
    {
        public static void PopulateDb(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            AddInitialData(serviceScope.ServiceProvider.GetService<ApplicationDbContext>()!);
        }

        private static void AddInitialData(ApplicationDbContext context)
        {
            if (!context.WeatherForecasts.Any())
            {
                var summaries = new[]
                {
                    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
                };

                var seedForecasts = Enumerable.Range(1, 20).Select(index =>
                       new WeatherForecast
                       {
                           Id = Guid.NewGuid(),
                           Date = DateTime.Now.AddDays(index),
                           Created = DateTime.Now.AddDays(-7),
                           Updated = DateTime.Now.AddDays(-5),
                           TemperatureC = Random.Shared.Next(-20, 55),
                           Summary = summaries[Random.Shared.Next(summaries.Length)]
                      })
                    .ToList();

                context.WeatherForecasts.AddRange(seedForecasts);
                context.SaveChanges();
                Console.WriteLine("Seeded data to the Database");
            }
        }
    }
}
