namespace MemoryCache.NET.CrossCutting.Tools;

public static class ServiceTool
{
    public static IServiceProvider ServiceProvider { get; private set; }

    public static void Create(IServiceCollection services)
    {
        ServiceProvider = services.BuildServiceProvider();
    }
}