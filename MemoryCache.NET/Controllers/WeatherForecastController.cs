using MemoryCache.NET.Models;
using MemoryCache.NET.Services;
using Microsoft.AspNetCore.Mvc;


namespace MemoryCache.NET.Controllers;

public class WeatherForecastController : ApiController
{
    private readonly IWeatherService _weatherService;
    public WeatherForecastController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<ActionResult<IEnumerable<WeatherModel>>> Get()
    {
        return Ok(await _weatherService.GetWeatherAsync());
    }
}