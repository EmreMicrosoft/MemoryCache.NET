using MemoryCache.NET.Aspects;
using MemoryCache.NET.Models;


namespace MemoryCache.NET.Services;

public interface IWeatherService
{
    [CacheAspect]
    Task<IEnumerable<WeatherModel>> GetWeatherAsync();
}