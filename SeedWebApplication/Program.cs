using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeedWebApplication.Data;
using SeedWebApplication.Data.Context;
using SeedWebApplication.Data.Repos;
using SeedWebApplication.DTOs;
using SeedWebApplication.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
         options.UseInMemoryDatabase("inmemo"));

builder.Services.AddScoped<IWeatherForecastRepo, WeatherForecastRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/weatherforecast", ([FromServices] IWeatherForecastRepo _weatherForecastRepo) =>
{
    var forecast = _weatherForecastRepo.GetAllWeatherForecasts().Select(fc => fc.WeatherForecastAsDto());
    return Results.Ok(forecast);
})
.WithName("GetWeatherForecast")
.Produces(statusCode: StatusCodes.Status200OK, responseType: typeof(IEnumerable<WeatherForecastDto>));


SeedData.PopulateDb(app);

app.Run();
