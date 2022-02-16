namespace MemoryCache.NET.CrossCut;

public interface ICacheManager
{
    T Get<T>(string key);
    object Get(string key);

    void Add(string key, object data, int durationMinute);
    bool IsAdd(string key);

    void Remove(string key);
    void RemoveByPattern(string pattern);
}