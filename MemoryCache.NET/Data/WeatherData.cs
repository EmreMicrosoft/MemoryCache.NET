namespace MemoryCache.NET.Data;

public class WeatherData
{
    public static async Task<IEnumerable<WeatherModel>> Get()
    {
        var weather = Enumerable.Range(1, 5).Select(index => new WeatherModel
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

        await Task.Delay(Random.Shared.Next(1000, 2000));

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