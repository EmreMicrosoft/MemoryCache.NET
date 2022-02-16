using MemoryCache.NET.Models;


namespace MemoryCache.NET.Services;

public class WeatherService : IWeatherService
{
    public async Task<IEnumerable<WeatherModel>> GetWeatherAsync()
    {
        var weather = Enumerable.Range(1, 5).Select(index => new WeatherModel
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

        await Task.Delay(Random.Shared.Next(10, 20));
        return weather;
    }


    private static readonly string[] Summaries =
    {
        "Freezing",
        "Bracing",
        "Chilly",
        "Cool",
        "Mild",
        "Warm",
        "Balmy",
        "Hot",
        "Sweltering",
        "Scorching"
    };
}