using MemoryCache.NET.CrossCutting.CacheManagement;
using MemoryCache.NET.CrossCutting.Interceptors;
using MemoryCache.NET.CrossCutting.Tools;


namespace MemoryCache.NET.Aspects;

public class CacheAspect : MethodInterceptor
{
    private readonly string _key;
    private readonly int _duration;
    private readonly ICacheManager _cacheManager;

    public CacheAspect(string key, int durationInMinute = 2)
    {
        _key = key;
        _duration = durationInMinute;
        _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
    }

    public override void Intercept(IInvocation invocation)
    {
        if (_cacheManager.IsExist(_key))
        {
            invocation.ReturnValue = _cacheManager.Get(_key);
            return;
        }
        invocation.Proceed();
        _cacheManager.Set(_key, invocation.ReturnValue, _duration);
    }
}