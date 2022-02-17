using MemoryCache.NET.Aspects;
using MemoryCache.NET.Data;


namespace MemoryCache.NET.Services;

public class WeatherService : IWeatherService
{
    [CacheAspect("WeatherForecast")]
    public async Task<IEnumerable<WeatherModel>> GetWeatherAsync()
    {
        //var weather = _cacheManager
        //    .Get<IEnumerable<WeatherModel>>("weather-forecast");

        //if (weather != null)
        //    return weather;

        var weather = await WeatherData.Get();

        //_cacheManager.Set(key: "WeatherForecast",
        //                  data: weather, durationMinute: 1);

        return weather;
    }
}