using MemoryCache.NET.CrossCutting.CacheManagement;
using MemoryCache.NET.Models;


namespace MemoryCache.NET.Services;

public class WeatherService : IWeatherService
{
    private readonly ICacheManager _cacheManager;
    public WeatherService(ICacheManager cacheManager)
    {
        _cacheManager = cacheManager;
    }


    public async Task<IEnumerable<WeatherModel>> GetWeatherAsync()
    {
        var weather = _cacheManager
            .Get<IEnumerable<WeatherModel>>("weather-forecast");

        if (weather != null)
            return weather;
        
        weather = Enumerable.Range(1, 5).Select(index => new WeatherModel
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
            .ToArray();

        await Task.Delay(Random.Shared.Next(1000, 2000));

        _cacheManager.Set(key: "weather-forecast",
                          data: weather, durationMinute: 1);

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