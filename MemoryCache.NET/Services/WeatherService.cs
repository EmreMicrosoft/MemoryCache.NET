using MemoryCache.NET.Data;
using Microsoft.Extensions.Caching.Memory;


namespace MemoryCache.NET.Services;

public class WeatherService : IWeatherService
{
    private readonly IMemoryCache _memoryCache;

    public WeatherService(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public async Task<IEnumerable<WeatherModel>> GetWeatherAsync()
    {
        var weather = _memoryCache
            .Get<IEnumerable<WeatherModel>>("weather-forecast");

        if (weather != null)
            return weather;

        weather = await WeatherData.Get();

        var weatherForecast = weather.ToList();
        _memoryCache.Set(key: "weather-forecast", weatherForecast);

        return weatherForecast;
    }
}