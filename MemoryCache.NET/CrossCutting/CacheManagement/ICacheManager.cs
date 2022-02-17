namespace MemoryCache.NET.CrossCutting.CacheManagement;

public interface ICacheManager
{
    T Get<T>(string key);
    object Get(string key);

    void Set(string key, object data, int durationInMinute);
    bool IsExist(string key);

    void Remove(string key);
    void RemoveByPattern(string pattern);
}