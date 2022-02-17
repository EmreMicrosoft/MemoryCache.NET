using System.Text.RegularExpressions;
using MemoryCache.NET.CrossCutting.Tools;
using Microsoft.Extensions.Caching.Memory;


namespace MemoryCache.NET.CrossCutting.CacheManagement;

public class CacheManager : ICacheManager
{
    private readonly IMemoryCache _memoryCache;

    public CacheManager()
    {
        _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
    }

    public void Set(string key, object value, int durationInMinute)
    {
        _memoryCache.Set(key, value,
            TimeSpan.FromMinutes(durationInMinute));
    }

    public T Get<T>(string key)
    {
        return _memoryCache.Get<T>(key);
    }

    public object Get(string key)
    {
        return _memoryCache.Get(key);
    }

    public bool IsExist(string key)
    {
        return _memoryCache.TryGetValue(key, out _);
    }

    public void Remove(string key)
    {
        _memoryCache.Remove(key);
    }

    public void RemoveByPattern(string pattern)
    {
        var cacheEntriesCollectionDefinition = typeof(Microsoft
                                        .Extensions.Caching.Memory.MemoryCache)
            .GetProperty("EntriesCollection",
                System.Reflection.BindingFlags.NonPublic
                | System.Reflection.BindingFlags.Instance);

        var cacheEntriesCollection = cacheEntriesCollectionDefinition?
            .GetValue(_memoryCache) as dynamic;

        var cacheCollectionValues = new List<ICacheEntry>();

        if (cacheEntriesCollection != null)
            foreach (var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheItem.GetType()
                    .GetProperty("Value").GetValue(cacheItem, null);

                cacheCollectionValues.Add(cacheItemValue);
            }

        var regex = new Regex(pattern,
            RegexOptions.Singleline
            | RegexOptions.Compiled
            | RegexOptions.IgnoreCase);

        var keysToRemove = cacheCollectionValues
            .Where(c => regex.IsMatch(c.Key.ToString()!))
            .Select(c => c.Key).ToList();

        foreach (var key in keysToRemove)
            _memoryCache.Remove(key);
    }
}