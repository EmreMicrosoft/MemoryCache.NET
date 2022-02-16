using MemoryCache.NET.Models;


namespace MemoryCache.NET.Services;

public interface IWeatherService
{
    Task<IEnumerable<WeatherModel>> GetWeatherAsync();
}