using MemoryCache.NET.CrossCutting.CacheManagement;
using MemoryCache.NET.CrossCutting.Tools;
using MemoryCache.NET.Services;
using Microsoft.Extensions.Caching.Memory;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var cacheService = new ServiceCollection();
ServiceTool.Create(cacheService);
ServiceTool.ServiceProvider.GetService<IMemoryCache>();

builder.Services.AddMemoryCache();
builder.Services.AddSingleton<ICacheManager, CacheManager>();

builder.Services.AddSingleton<IWeatherService, WeatherService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();