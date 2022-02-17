using MemoryCache.NET.Data;


namespace MemoryCache.NET.Services;

public interface IWeatherService
{
    Task<IEnumerable<WeatherModel>> GetWeatherAsync();
}